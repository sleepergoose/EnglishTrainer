using Microsoft.AspNetCore.Http;
using OneOf;
using OneOf.Types;
using Shared.AzureBlobStorage;
using System.Threading.Tasks;
using Shared.RabbitMQ.Wrapper.Services;
using Shared.RabbitMQ.Wrapper.Interfaces;
using Shared.RabbitMQ.Wrapper.Models;
using Microsoft.Extensions.Options;
using Shared.RabbitMQ.Wrapper.Options;
using Shared.AzureBlobStorage.Models;
using System.IO;
using System;
using System.Text.Json;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class BooksService
    {
        private readonly IMessageService _messageService;
        private readonly ScopeSettings _producerSettings;
        private readonly ScopeSettings _consumerSettings;

        public BooksService(IMessageService messageService,
            IOptions<BookProcessingRabbitMQOptions> rabbitMqOptions)
        {
            _messageService = messageService;

            var options = rabbitMqOptions.Value;
            _producerSettings = options.ProducerSettings;
            _consumerSettings = options.ConsumerSettings;
        }

        public async Task<OneOf<Success, Error>> UploadBooksAsync(IFormFile[] files)
        {
            _messageService.SetMessageService(_producerSettings, null);

            foreach (var file in files)
            {
                var data = new BookDataTransferModel
                {
                    BookBlobId = Guid.NewGuid().ToString(),
                    BookName = file.FileName,
                    ContentType = file.ContentType
                };

                MemoryStream memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                data.BookBody = memoryStream.ToArray(); 

                var body = BinaryData.FromObjectAsJson(data).ToArray();

                _messageService.SendDataToQueue(body);
            }

            return new Success();
        }
    }
}
