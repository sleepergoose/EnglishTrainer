using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;

namespace Trainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasalVerbsController : ControllerBase
    {
        private readonly PhrasalVerbsService _pvService;

        public PhrasalVerbsController(PhrasalVerbsService pvService)
        {
            _pvService = pvService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _pvService.GetPhrasalVerbAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _pvService.GetPhrasalVerbsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] PhrasalVerbDTO dto)
        {
            return Ok(await _pvService.CreatePhrasalVerbAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] PhrasalVerbDTO dto)
        {
            return Ok(await _pvService.UpdatePhrasalVerbAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _pvService.DeletePhrasalVerbAsync(id));
        }
    }
}
