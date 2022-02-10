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
    public class CreatePvTrackCommand : IRequest<PvTrack>
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }

    public class CreatePvTrackCommandHandler : IRequestHandler<CreatePvTrackCommand, PvTrack>
    {
        private readonly IDbConnection _dbConnection;

        public CreatePvTrackCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PvTrack> Handle(CreatePvTrackCommand command, CancellationToken cancellationToken)
        {
            var track = new PvTrack
            {
                Name = command.Name,
                Description = command.Description,
                Level = command.Level,
                AuthorId = command.AuthorId,
                CreatedAt = DateTimeOffset.Now
            };

            // Is there a track with such a name?
            const string sql_0 =
                @"SELECT * FROM PvTracks WHERE Name=@Name";
            var existedTrack = (await _dbConnection.QueryAsync<PvTrack>(sql_0, track)).FirstOrDefault();

            if (existedTrack != null)
                return track;

            const string sql_1 =
                @"INSERT INTO PvTracks (
                    Name, 
                    Description,
                    Level, 
                    AuthorId, 
                    CreatedAt)
                VALUES (
                    @Name, 
                    @Description,
                    @Level, 
                    @AuthorId, 
                    @CreatedAt)
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _dbConnection.QueryFirstAsync<int>(sql_1, track);
            track.Id = id;

            return track;
        }
    }
}
