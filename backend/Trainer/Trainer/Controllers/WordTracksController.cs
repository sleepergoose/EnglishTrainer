using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.Auth.Constants;
using Trainer.Common.DTO;
using Trainer.Common.DTO.WordTrackDTO;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("words/{id}")]
        public async Task<IActionResult> GetWordsByTrackIdAsync(int id)
        {
            return Ok(await _wtService.GetWordsByTrackIdAsync(id));
        }

        [HttpGet("newReleases/{amount}")]
        public async Task<IActionResult> GetNewReleasesAsync(int amount)
        {
            return Ok(await _wtService.GetNewReleasesAsync(amount));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] WordTrackWriteDTO dto)
        {
            return Ok(await _wtService.CreateWordTrackAsync(dto));
        }

        [HttpPost("addWordToTrack")]
        public async Task<IActionResult> AddWordToTrackAsync([FromBody] WordToTrackWriteDTO dto)
        {
            return Ok(await _wtService.AddWordToTrackAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] WordTrackReadDTO dto)
        {
            return Ok(await _wtService.UpdateWordTrackAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _wtService.DeleteWordTrackAsync(id));
        }

        [HttpPost("removeWord")]
        public async Task<IActionResult> RemoveWordFromTrackAsync(WordToTrackWriteDTO dto)
        {
            return Ok(await _wtService.RemoveWordFromTrackAsync(dto));
        }

        [HttpGet("getByAuthorId/{authorId}")]
        public async Task<IActionResult> GetTracksByAuthorIdAsync(int authorId)
        {
            return Ok(await _wtService.GetTracksByAuthorIdAsync(authorId));
        }
    }
}
