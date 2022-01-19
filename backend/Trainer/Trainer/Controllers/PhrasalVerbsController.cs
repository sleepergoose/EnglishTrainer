using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;

namespace Trainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
    }
}
