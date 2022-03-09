using Microsoft.AspNetCore.Http;
using OneOf;
using OneOf.Types;
using Shared.AzureBlobStorage;
using System.Threading.Tasks;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class BooksService
    {
        private readonly BlobService _blobService;

        public BooksService(BlobService blobService)
        {
            _blobService = blobService;
        }

        public async Task<OneOf<Success, Error>> UploadBooksAsync(IFormFile[] files)
        {
            foreach (var file in files)
            {
                await _blobService.UploadAsync(file.OpenReadStream(), file.FileName, file.ContentType);
            }

            return new Success();
        }
    }
}
