using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using Trainer.Admin.BusinessLogic.Commands;
using Trainer.Admin.Domain.Entities;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class WordsService
    {
        private readonly IMediator _mediator;

        public WordsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Word> CreateWordAsync(WordWrite word)
        {
            return await _mediator.Send(new CreateWordCommand()
            {
                Text = word.Text,
                Transcription = word.Transcription,
                Translation = word.Translation,
                Examples = word.Examples
            });
        }
    }
}
