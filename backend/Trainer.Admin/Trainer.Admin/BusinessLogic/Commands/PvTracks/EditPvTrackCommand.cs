using Dapper;
using MediatR;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class EditPvTrackCommand : IRequest<PvTrack>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }

    public class EditPvTrackCommandHandler : IRequestHandler<EditPvTrackCommand, PvTrack>
    {
        private readonly IDbConnection _dbConnection;

        public EditPvTrackCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PvTrack> Handle(EditPvTrackCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var track = new PvTrack
                {
                    Id = command.Id,
                    Name = command.Name,
                    Description = command.Description,
                    Level = command.Level
                };

                const string sql_0 =
                    @"UPDATE 
                    PvTracks
                SET
                    Name = @Name, 
                    Description = @Description,
                    Level = @Level
                WHERE Id = @Id";

                await _dbConnection.ExecuteAsync(sql_0, track);

                return track;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
