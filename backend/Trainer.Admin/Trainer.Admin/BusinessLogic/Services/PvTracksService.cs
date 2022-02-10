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
    }
}
