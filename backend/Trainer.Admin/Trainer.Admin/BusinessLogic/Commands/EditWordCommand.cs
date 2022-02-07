using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using Trainer.Admin.Domain.Entities;
using System.Linq;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class EditWordCommand : WordEdit, IRequest<Word>
    {}

    public class EditWordCommandHandler : IRequestHandler<EditWordCommand, Word>
    {
        private readonly IDbConnection _dbConnection;

        public EditWordCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Word> Handle(EditWordCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var word = new Word()
                {
                    Id = command.Id,
                    CreatedAt = DateTimeOffset.Now,
                    Text = command.Text,
                    Transcription = command.Transcription,
                    Translation = command.Translation,
                    Examples = new List<WordExample>()
                };

                // Is there the added word?
                const string sql_0 =
                    @"SELECT * FROM Words WHERE Id=@Id";
                var existedWord = (await _dbConnection.QueryAsync<Word>(sql_0, word)).FirstOrDefault();

                if (existedWord == null)
                    throw new Exception("There is no such a word");

                // Update the word
                const string sql_1 =
                    @"UPDATE Words SET 
                    Text=@Text,
                    Transcription=@Transcription,
                    Translation=@Translation
                WHERE Id=@Id";
                await _dbConnection.ExecuteAsync(sql_1, word);

                // Delete all word's examples
                string sql_2 = $"DELETE FROM WordExamples WHERE WordId={word.Id}";
                await _dbConnection.ExecuteAsync(sql_2);

                // Add all word's examples
                foreach (var item in command.Examples)
                {
                    var example = new WordExample
                    {
                        WordId = command.Id,
                        Phrase = item.Phrase,
                        Translation = item.Translation,
                        CreatedAt = DateTimeOffset.Now
                    };

                    const string sql_3 =
                        @"INSERT INTO WordExamples (
                        WordId, Phrase, Translation, CreatedAt)
                    VALUES (
                        @WordId, @Phrase, @Translation, @CreatedAt)
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                    var example_id = await _dbConnection.QueryFirstAsync<int>(sql_3, example);
                    example.Id = example_id;

                    word.Examples.Add(example);
                }

                return word;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
