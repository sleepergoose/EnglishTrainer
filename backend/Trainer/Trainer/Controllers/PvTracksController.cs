using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PvTracksController : ControllerBase
    {
        private readonly PvTracksService _pvtService;

        public PvTracksController(PvTracksService pvtService)
        {
            _pvtService = pvtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _pvtService.GetPvTrackAsync(id));
        }

        [HttpGet("phrasalVerbs/{id}")]
        public async Task<IActionResult> GetWordsByTrackIdAsync(int id)
        {
            return Ok(await _pvtService.GetPvByTrackIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _pvtService.GetPvTracksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] PvTrackWriteDTO dto)
        {
            return Ok(await _pvtService.CreatePvTrackAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] PvTrackWriteDTO dto)
        {
            return Ok(await _pvtService.UpdatePvTrackAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _pvtService.DeletePvTrackAsync(id));
        }
    }
}
