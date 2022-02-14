using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Admin.BusinessLogic.Commands;
using Trainer.Admin.Domain.Entities;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class PvTracksService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PvTracksService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PhrasalVerbTrackRead> CreatePvTrackAsync(PhrasalVerbTrackWrite track)
        {
            var command = new CreatePvTrackCommand
            {
                AuthorId = track.AuthorId,
                Description = track.Description,
                Level = track.Level,
                Name = track.Name
            };

            return _mapper.Map<PhrasalVerbTrackRead>(await _mediator.Send(command));
        }

        public async Task<PhrasalVerbTrackRead> EditPvTrackAsync(PhrasalVerbTrackRead track)
        {
            var command = new EditPvTrackCommand
            {
                Id = track.Id,
                Name = track.Name,
                Description = track.Description,
                Level = track.Level
            };

            return _mapper.Map<PhrasalVerbTrackRead>(await _mediator.Send(command));
        }

        public async Task<Unit> AddVerbToTrackAsync(PhrasalVerbToTrack verb)
        {
            var command = new AddPvToTrackCommand
            {
                TrackId = verb.TrackId,
                VerbId = verb.VerbId
            };

            return _mapper.Map<Unit>(await _mediator.Send(command));
        }

        public async Task<Unit> RemoveVerbToTrackAsync(PhrasalVerbToTrack verb)
        {
            var command = new RemovePvToTrackCommand
            {
                TrackId = verb.TrackId,
                VerbId = verb.VerbId
            };

            return _mapper.Map<Unit>(await _mediator.Send(command));
        }
    }
}
