using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.Admin.BusinessLogic.Services;
using Trainer.Admin.Domain.Entities;
using Trainer.Common.Auth.Constants;

namespace Trainer.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsUser)]
    public class PvTracksController : ControllerBase
    {
        private readonly PvTracksService _pvTrackService;

        public PvTracksController(PvTracksService pvTrackService)
        {
            _pvTrackService = pvTrackService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePvTrackAsync([FromBody] PhrasalVerbTrackWrite track)
        {
            return Ok(await _pvTrackService.CreatePvTrackAsync(track));
        }

        [HttpPut]
        public async Task<IActionResult> EditPvTrackAsync([FromBody] PhrasalVerbTrackRead track)
        {
            return Ok(await _pvTrackService.EditPvTrackAsync(track));
        }

        [HttpPost("addVerbToTrack")]
        public async Task<IActionResult> AddVerbToTrackAsync([FromBody] PhrasalVerbToTrack verb)
        {
            return Ok(await _pvTrackService.AddVerbToTrackAsync(verb));
        }

        [HttpPost("removeVerbFromTrack")]
        public async Task<IActionResult> RemoveVerbToTrackAsync([FromBody] PhrasalVerbToTrack verb)
        {
            return Ok(await _pvTrackService.RemoveVerbToTrackAsync(verb));
        }
    }
}
