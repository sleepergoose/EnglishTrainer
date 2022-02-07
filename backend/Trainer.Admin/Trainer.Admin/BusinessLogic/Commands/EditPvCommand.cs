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
    public class EditPvCommand : PhrasalVerbWrite, IRequest<PhrasalVerb>
    {}

    public class EditPvCommandHandler : IRequestHandler<EditPvCommand, PhrasalVerb>
    {
        private readonly IDbConnection _dbConnection;

        public EditPvCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PhrasalVerb> Handle(EditPvCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var verb = new PhrasalVerb()
                {
                    Id = command.Id,
                    Text = command.Text,
                    Translation = command.Translation,
                    Examples = new List<PvExample>(),
                    CreatedAt = DateTimeOffset.Now
                };

                // Is there the added word?
                const string sql_0 =
                    @"SELECT * FROM PhrasalVerbs WHERE Id=@Id";
                var existedVerb = (await _dbConnection.QueryAsync<Word>(sql_0, verb)).FirstOrDefault();

                if (existedVerb == null)
                    throw new Exception("There is no such a phrasal verb");

                // Update the word
                const string sql_1 =
                    @"UPDATE PhrasalVerbs SET 
                    Text=@Text,
                    Translation=@Translation
                WHERE Id=@Id";
                await _dbConnection.ExecuteAsync(sql_1, verb);

                // Delete all word's examples
                string sql_2 = $"DELETE FROM PvExamples WHERE PhrasalVerbId={verb.Id}";
                await _dbConnection.ExecuteAsync(sql_2);

                // Add all word's examples
                foreach (var item in command.Examples)
                {
                    var example = new PvExample
                    {
                        PhrasalVerbId = command.Id,
                        Phrase = item.Phrase,
                        Translation = item.Translation,
                        CreatedAt = DateTimeOffset.Now
                    };

                    const string sql_3 =
                        @"INSERT INTO PvExamples (
                        PhrasalVerbId, Phrase, Translation, CreatedAt)
                    VALUES (
                        @PhrasalVerbId, @Phrase, @Translation, @CreatedAt)
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                    var example_id = await _dbConnection.QueryFirstAsync<int>(sql_3, example);
                    example.Id = example_id;

                    verb.Examples.Add(example);
                }

                return verb;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
