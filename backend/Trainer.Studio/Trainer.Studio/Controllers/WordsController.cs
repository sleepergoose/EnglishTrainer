using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Common.Auth.Constants;
using Trainer.Domain.Models;
using Trainer.Studio.BusinessLogic.Services;
using Trainer.Studio.Domain.Entities;

namespace Trainer.Studio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsAdmin)]
    public class WordsController : ControllerBase
    {
        private readonly WordsService _wordsService;

        public WordsController(WordsService wordsService)
        {
            _wordsService = wordsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWordAsync(WordWrite word)
        {
            return Ok(await _wordsService.CreateWordAsync(word));
        }
    }
}
