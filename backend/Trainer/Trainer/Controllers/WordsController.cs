using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;
using Trainer.Common.Auth.Constants;

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
        [Authorize(Policy = Policies.IsUser)]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _wordsService.GetWordAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _wordsService.GetWordsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] WordDTO dto)
        {
            return Ok(await _wordsService.CreateWordAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] WordDTO dto)
        {
            return Ok(await _wordsService.UpdateWordAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _wordsService.DeleteWordAsync(id));
        }
    }
}
