using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainer.Common.Auth.Constants;

namespace Trainer.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.IsAdmin)]
    public class BooksController : ControllerBase
    {

        [HttpPost("uploadBooks")]
        public IActionResult UploadBooksAsync([FromForm] IFormFile[] form)
        {
            // TODO: make a service to send files via RabbitMQ to Processor for saving into Blob Storage
            return Ok();
        }
    }
}
