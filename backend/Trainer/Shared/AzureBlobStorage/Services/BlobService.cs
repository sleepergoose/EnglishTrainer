using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Shared.AzureBlobStorage
{
    public sealed class BlobService : IBlobService
    {
        private readonly string _connectionString;
        private BlobClient _blob = default;

        public BlobService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BlobStorage");
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            _blob = await GetBlobClientAsync(fileName);

            if (_blob != null)
            {
                await _blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                await _blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

                return _blob.Uri.ToString();
            }
            else
            {
                throw new Exception("BlobClient can't be null");
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {
            _blob = await GetBlobClientAsync(fileName);
            
            if (_blob != null)
                await _blob?.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        private async Task<BlobClient> GetBlobClientAsync(string fileName)
        {
            var container = new BlobContainerClient(_connectionString, "books-container");
            var createResponse = await container.CreateIfNotExistsAsync();

            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);

            return container.GetBlobClient(fileName);
        }
    }
}
