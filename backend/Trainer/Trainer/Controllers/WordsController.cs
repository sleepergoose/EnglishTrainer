using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.BL.Services;

namespace Trainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordsService _wordsService;

        public WordsController(WordsService wordsService)
        {
            _wordsService = wordsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWord(int id)
        {
            return Ok(await _wordsService.GetWord(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetWords()
        {
            return Ok(await _wordsService.GetWords());
        }
    }
}
