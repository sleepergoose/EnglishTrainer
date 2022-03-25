using Dapper;
using MediatR;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public sealed class RemovePvToTrackCommand : IRequest<Unit>
    {
        public int TrackId { get; set; }
        public int VerbId { get; set; }
    }

    public sealed class RemovePvToTrackCommandHandler : IRequestHandler<RemovePvToTrackCommand, Unit>
    {
        private readonly IDbConnection _dbConnection;

        public RemovePvToTrackCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Unit> Handle(RemovePvToTrackCommand command, CancellationToken cancellationToken)
        {
            var row = new
            {
                PvTrackId = command.TrackId,
                PhrasalVerbId = command.VerbId
            };

            string sql_0 =
                @"SELECT * FROM 
                    PvToTracks 
                WHERE 
                    PvTrackId = @PvTrackId 
                AND
                    PhrasalVerbId = @PhrasalVerbId";

            int existedVerbId = (await _dbConnection.QueryAsync<int>(sql_0, row)).FirstOrDefault();

            if (existedVerbId == 0)
                return new Unit();

            string sql_1 = @$"DELETE FROM PvToTracks WHERE Id = {existedVerbId}";

            await _dbConnection.ExecuteAsync(sql_1);

            return new Unit();
        }
    }
}
