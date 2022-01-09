using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PvExamplesController : ControllerBase
    {
        private readonly PvExamplesService _pveService;

        public PvExamplesController(PvExamplesService pveService)
        {
            _pveService = pveService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAsync(int id)
        {
            return Ok(await _pveService.GetPvExampleAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            return Ok(await _pveService.GetPvExamplesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntiyAsync([FromBody] PvExampleDTO dto)
        {
            return Ok(await _pveService.CreatePvExampleAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntiyAsync([FromBody] PvExampleDTO dto)
        {
            return Ok(await _pveService.UpdatePvExampleAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            return Ok(await _pveService.DeletePvExampleAsync(id));
        }
    }
}
