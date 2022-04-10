using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Processor.Interfaces;
using Processor.Models;
using Shared.AzureBlobStorage;
using Shared.AzureBlobStorage.Models;
using Shared.RabbitMQ.Wrapper.Interfaces;
using Shared.RabbitMQ.Wrapper.Models;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Processor.Services
{
    internal class BookService : IBookService
    {
        private readonly IMessageService _messageService;
        private readonly IBlobService _blobService;
        private readonly ScopeSettings _producerSettings;
        private readonly ScopeSettings _consumerSettings;

        public BookService(IBlobService blobService, IMessageService messageService,
            IOptions<BookProcessingRabbitMQOptions> rabbitMqOptions)
        {
            _messageService = messageService;
            _blobService = blobService;

            var options = rabbitMqOptions.Value;
            _producerSettings = options.ProducerSettings;
            _consumerSettings = options.ConsumerSettings;
        }

        public void Start()
        {
            _messageService.SetMessageService(null, _consumerSettings);
            _messageService.MessageReceived += BookReceived;

            Console.WriteLine("Book processing is started at {0}", DateTime.Now.ToShortTimeString());
        }

        private void BookReceived(byte[] body)
        {
            var json = Encoding.UTF8.GetString(body);

            var data = JsonSerializer.Deserialize<BookDataTransferModel>(json);

            Console.WriteLine($"{data!.BookName} is received");

            var stream = new MemoryStream(data!.BookBody);

            var uri = _blobService.UploadAsync(stream, data.BookBlobId, data.ContentType).Result;

            Console.WriteLine($"{data!.BookName} is saved by {uri}");
        }
    }
}
