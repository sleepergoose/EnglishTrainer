using System.IO;
using System.Threading.Tasks;

namespace Shared.AzureBlobStorage
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
        Task<string> GetBookAsync(string blobId);
        Task DeleteFileAsync(string fileName);
    }
}
