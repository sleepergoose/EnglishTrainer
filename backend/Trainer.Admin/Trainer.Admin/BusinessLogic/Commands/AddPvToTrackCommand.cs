using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class AddPvToTrackCommand : IRequest
    {
        public int TrackId { get; set; }
        public int VerbId { get; set; }
    }

    public class AddPvToTrackCommandHandler : IRequestHandler<AddPvToTrackCommand>
    {
        private readonly IDbConnection _dbConnection;

        public AddPvToTrackCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Unit> Handle(AddPvToTrackCommand command, CancellationToken cancellationToken)
        {
            var pvToTrack = new
            {
                PvTrackId = command.TrackId,
                PhrasalVerbId = command.VerbId,
                CreatedAt = DateTimeOffset.Now
            };

            var sql_0 = 
                @"INSERT INTO PvToTracks (
                    PvTrackId, PhrasalVerbId, CreatedAt)
                VALUES (
                    @PvTrackId, @PhrasalVerbId, @CreatedAt)";

            await _dbConnection.ExecuteAsync(sql_0, pvToTrack);

            return new Unit();
        }
    }
}
