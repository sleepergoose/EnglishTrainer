using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using Trainer.Admin.Domain.Entities;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class CreateWordCommand : IRequest<Word>
    {
        public string Text { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public ICollection<Example> Examples { get; set; }
    }

    public class CreateWordCommandHandler : IRequestHandler<CreateWordCommand, Word>
    {
        private readonly IDbConnection _dbConnection;

        public CreateWordCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Word> Handle(CreateWordCommand command, CancellationToken cancellationToken)
        {
            var word = new Word()
            {
                Id = 0,
                CreatedAt = DateTimeOffset.Now,
                Text = command.Text,
                Transcription = command.Transcription,
                Translation = command.Translation
            };

            const string sql_1 =
                @"INSERT INTO Words (
                    Text, Transcription, Translation, CreatedAt)
                VALUES (
                    @Text, @Transcription, @Translation, @CreatedAt)
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _dbConnection.QueryFirstAsync<int>(sql_1, word);
            word.Id = id;

            word.Examples = new List<WordExample>();

            foreach (var item in command.Examples)
            {
                var example = new WordExample
                {
                    Id = 0,
                    WordId = id,
                    Phrase = item.Phrase,
                    Translation = item.Translation,
                    CreatedAt = DateTimeOffset.Now
                };

                const string sql_2 =
                    @"INSERT INTO WordExamples (
                        WordId, Phrase, Translation, CreatedAt)
                    VALUES (
                        @WordId, @Phrase, @Translation, @CreatedAt)
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                var example_id = await _dbConnection.QueryFirstAsync<int>(sql_2, example);
                example.Id = example_id;

                word.Examples.Add(example);
            }

            return word;
        }
    }
}
