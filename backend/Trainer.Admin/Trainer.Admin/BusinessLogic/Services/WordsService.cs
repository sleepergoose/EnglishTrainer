using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using Trainer.Admin.BusinessLogic.Commands;
using Trainer.Admin.Domain.Entities;
using Trainer.Common.DTO.Word;
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
            var createdWord = await _mediator.Send(new CreateWordCommand()
                {
                    Text = word.Text,
                    Transcription = word.Transcription,
                    Translation = word.Translation,
                    Examples = word.Examples
                });

            return _mapper.Map<WordRead>(createdWord);
        }

        public async Task<WordRead> EditWordAsync(WordEdit word)
        {
            var editedWord = await _mediator.Send(new EditWordCommand()
            {
                Id = word.Id,
                Text = word.Text,
                Transcription = word.Transcription,
                Translation = word.Translation,
                Examples = word.Examples
            });

            return _mapper.Map<WordRead>(editedWord);
        }
    }
}
