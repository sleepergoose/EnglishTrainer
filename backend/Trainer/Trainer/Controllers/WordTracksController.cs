using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordTracksController : ControllerBase
    {
        private readonly WordTracksService _wtService;

        public WordTracksController(WordTracksService wtService)
        {
            _wtService = wtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _wtService.GetWordTrackAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _wtService.GetWordTracksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] WordTrackWriteDTO dto)
        {
            return Ok(await _wtService.CreateWordTrackAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] WordTrackWriteDTO dto)
        {
            return Ok(await _wtService.UpdateWordTrackAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _wtService.DeleteWordTrackAsync(id));
        }
    }
}
