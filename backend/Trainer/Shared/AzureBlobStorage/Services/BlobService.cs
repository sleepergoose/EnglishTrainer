using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Shared.AzureBlobStorage
{
    public sealed class BlobService : IBlobService
    {
        private readonly string _connectionString;

        public BlobService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BlobStorage");
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            var container = new BlobContainerClient(_connectionString, "books-container");
            var createResponse = await container.CreateIfNotExistsAsync();

            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);

            var blob = container.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

            return blob.Uri.ToString();
        }
    }
}
