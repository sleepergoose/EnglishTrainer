using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.DTO.Auth;
using Trainer.Common.Auth.Constants;

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
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDataDTO dto)
        {
            return (await _authService.RegisterAsync(dto)).Match<IActionResult>(
                success => Ok(),
                error => BadRequest()
            );
        }

        [HttpPost("login")]
        [Authorize]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO dto)
        {
            return (await _authService.LoginAsync(dto)).Match<IActionResult>(
                success => Ok(),
                error => BadRequest()
            );
        }
    }
}
