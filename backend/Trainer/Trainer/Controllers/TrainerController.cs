using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.BL.Services;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerService _trainerService;

        public TrainerController(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet("wordsByTrackId/{trackId}")]
        public async Task<IActionResult> GetWordsByTrackIdAsync(int trackId)
        {
            return Ok(await _trainerService.GetWordsByTrackIdAsync(trackId));
        }

        [HttpGet("getTrackById/{trackId}")]
        public async Task<IActionResult> GetTrackByIdAsync(int trackId)
        {
            return Ok(await _trainerService.GetTrackByIdAsync(trackId));
        }
    }
}
