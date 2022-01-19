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

        public PhrasalVerbsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PhrasalVerb> CreatePvAsync(PhrasalVerbWrite verb)
        {
            return await _mediator.Send(new CreatePvCommand
            {
                Text = verb.Text,
                Translation = verb.Translation,
                Examples = verb.Examples
            });
        }

        public async Task<PhrasalVerb> EditPvAsync(PhrasalVerbWrite verb)
        {
            return await _mediator.Send(new EditPvCommand
            {
                Id = verb.Id,
                Text = verb.Text,
                Translation = verb.Translation,
                Examples = verb.Examples
            });
        }
    }
}
