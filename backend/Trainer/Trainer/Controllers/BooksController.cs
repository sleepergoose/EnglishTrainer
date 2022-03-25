using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.BL.Services;
using Trainer.Common.Auth.Constants;

namespace Trainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsUser)]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await _booksService.GetBooksAsync());
        }
    }
}
