using System;

namespace Shared.AzureBlobStorage.Models
{
    public class BookDataTransferModel
    {
        public string BookBlobId { get; init; } = string.Empty;
        public string BookName { get; init; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] BookBody { get; set; } = default!;
    }
}
