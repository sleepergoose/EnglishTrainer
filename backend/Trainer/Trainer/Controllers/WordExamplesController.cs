using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordExamplesController : ControllerBase
    {
        private readonly WordExamplesService _weService;

        public WordExamplesController(WordExamplesService weService)
        {
            _weService = weService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _weService.GetWordExampleAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _weService.GetWordExamplesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] WordExampleDTO dto)
        {
            return Ok(await _weService.CreateWordExampleAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] WordExampleDTO dto)
        {
            return Ok(await _weService.UpdateWordExampleAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _weService.DeleteWordExampleVerbAsync(id));
        }
    }
}
