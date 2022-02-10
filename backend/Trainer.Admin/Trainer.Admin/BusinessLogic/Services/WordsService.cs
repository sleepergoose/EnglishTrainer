using MediatR;
using System.Threading.Tasks;
using Trainer.Admin.Domain.Entities;
using AutoMapper;
using Trainer.Admin.BusinessLogic.Commands;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class WordsService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WordsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<WordRead> CreateWordAsync(WordWrite word)
        {
            var command = new CreateWordCommand
            {
                Text = word.Text,
                Transcription = word.Transcription,
                Translation = word.Translation,
                Examples = word.Examples
            };

            return _mapper.Map<WordRead>(await _mediator.Send(command));
        }

        public async Task<WordRead> EditWordAsync(WordEdit word)
        {
            var command = new EditWordCommand
            {
                Id = word.Id,
                Text = word.Text,
                Transcription = word.Transcription,
                Translation = word.Translation,
                Examples = word.Examples
            };

            return _mapper.Map<WordRead>(await _mediator.Send(command));
        }
    }
}
