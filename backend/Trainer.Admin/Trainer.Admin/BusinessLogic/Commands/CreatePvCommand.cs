using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class CreatePvCommand : IRequest<PhrasalVerb>
    {
        public string Text { get; set; }
        public string Translation { get; set; }
        public ICollection<Example> Examples { get; set; }
    }

    public class CreatePvCommandHandler : IRequestHandler<CreatePvCommand, PhrasalVerb>
    {
        private readonly IDbConnection _dbConnection;

        public CreatePvCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PhrasalVerb> Handle(CreatePvCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var verb = new PhrasalVerb()
                {
                    Id = 0,
                    CreatedAt = DateTimeOffset.Now,
                    Text = command.Text,
                    Translation = command.Translation,
                    Examples = new List<PvExample>()
                };

                // Is there the added word?
                const string sql_0 =
                    @"SELECT * FROM PhrasalVerbs WHERE Text=@Text";
                var existedVerb = (await _dbConnection.QueryAsync<PhrasalVerb>(sql_0, verb)).FirstOrDefault();

                if (existedVerb != null)
                    return verb;

                const string sql_1 =
                    @"INSERT INTO PhrasalVerbs (
                    Text, Translation, CreatedAt)
                VALUES (
                    @Text, @Translation, @CreatedAt)
                SELECT CAST(SCOPE_IDENTITY() as int)";

                var id = await _dbConnection.QueryFirstAsync<int>(sql_1, verb);
                verb.Id = id;

                verb.Examples = new List<PvExample>();

                foreach (var item in command.Examples)
                {
                    var example = new PvExample
                    {
                        Id = 0,
                        PhrasalVerbId = id,
                        Phrase = item.Phrase,
                        Translation = item.Translation,
                        CreatedAt = DateTimeOffset.Now
                    };

                    const string sql_2 =
                        @"INSERT INTO PvExamples (
                        PhrasalVerbId, Phrase, Translation, CreatedAt)
                    VALUES (
                        @PhrasalVerbId, @Phrase, @Translation, @CreatedAt)
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                    var example_id = await _dbConnection.QueryFirstAsync<int>(sql_2, example);
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
