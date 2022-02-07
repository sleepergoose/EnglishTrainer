using MediatR;
using System.Threading.Tasks;
using Trainer.Admin.Domain.Entities;
using AutoMapper;

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
            return _mapper.Map<WordRead>(await _mediator.Send(word));
        }

        public async Task<WordRead> EditWordAsync(WordEdit word)
        {
            return _mapper.Map<WordRead>(await _mediator.Send(word));
        }
    }
}
