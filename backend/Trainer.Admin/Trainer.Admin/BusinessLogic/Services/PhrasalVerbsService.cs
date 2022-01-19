using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using Trainer.Admin.BusinessLogic.Commands;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class PhrasalVerbsService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PhrasalVerbsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PhrasalVerbRead> CreatePvAsync(PhrasalVerbWrite verb)
        {
            var pv = await _mediator.Send(new CreatePvCommand
            {
                Text = verb.Text,
                Translation = verb.Translation,
                Examples = verb.Examples
            });

            return _mapper.Map<PhrasalVerbRead>(pv);
        }

        public async Task<PhrasalVerbRead> EditPvAsync(PhrasalVerbWrite verb)
        {
            var pv = await _mediator.Send(new EditPvCommand
            {
                Id = verb.Id,
                Text = verb.Text,
                Translation = verb.Translation,
                Examples = verb.Examples
            });

            return _mapper.Map<PhrasalVerbRead>(pv);
        }
    }
}
