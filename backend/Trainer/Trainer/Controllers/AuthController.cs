using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO.Auth;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDataDTO dto)
        {
            return (await _authService.RegisterAsync(dto)).Match<IActionResult>(
                success => Ok(),
                error => BadRequest()
            );
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO dto)
        {
            return (await _authService.LoginAsync(dto)).Match<IActionResult>(
                success => Ok(),
                error => BadRequest()
            );
        }
    }
}
