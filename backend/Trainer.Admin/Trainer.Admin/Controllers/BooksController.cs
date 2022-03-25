using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using Trainer.Admin.BusinessLogic.Services;
using Trainer.Admin.Domain.Entities;
using Trainer.Common.Auth.Constants;

namespace Trainer.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsAdmin)]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("uploadBooks")]
        public async Task<IActionResult> UploadBooksAsync([FromForm] IFormFile[] form)
        {
            var result = await _booksService.UploadBooksAsync(form);

            return result.Match<ActionResult>(
                success => Ok(result.AsT0),
                error => BadRequest()
                );
        }

        [HttpPut]
        public async Task<IActionResult> EditBookAsync(BookRead book)
        {
            var result = await _booksService.EditBookAsync(book);

            return result.Match<ActionResult>(
                success => Ok(result.AsT0),
                error => BadRequest()
                );
        }
    }
}
