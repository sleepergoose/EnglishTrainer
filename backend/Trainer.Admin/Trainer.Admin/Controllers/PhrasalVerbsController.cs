using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Admin.BusinessLogic.Services;
using Trainer.Admin.Domain.Entities;
using Trainer.Common.Auth.Constants;

namespace Trainer.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsAdmin)]
    public class PhrasalVerbsController : ControllerBase
    {
        private readonly PhrasalVerbsService _pvService;

        public PhrasalVerbsController(PhrasalVerbsService pvService)
        {
            _pvService = pvService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePvAsync(PhrasalVerbWrite verb)
        {
            return Ok(await _pvService.CreatePvAsync(verb));
        }
    }
}
