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
    }
}
