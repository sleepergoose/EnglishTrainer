using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Processor.Interfaces;
using Processor.Models;
using Shared.RabbitMQ.Wrapper.Interfaces;
using Shared.RabbitMQ.Wrapper.Models;
using System;
using System.Text;

namespace Processor.Services
{
    internal class BookService : IBookService
    {
        private readonly IMessageService _messageService;
        private readonly ScopeSettings _producerSettings;
        private readonly ScopeSettings _consumerSettings;

        public BookService(
            
            IMessageService messageService,
            IOptions<BookProcessingRabbitMQOptions> rabbitMqOptions)
        {
            _messageService = messageService;

            var options = rabbitMqOptions.Value;
            _producerSettings = options.ProducerSettings;
            _consumerSettings = options.ConsumerSettings;
        }

        public void Start()
        {
            _messageService.SetMessageService(_producerSettings, _consumerSettings);
            _messageService.MessageReceived += BookReceived;
        }

        private void BookReceived(byte[] body)
        {
            Console.WriteLine(Encoding.UTF8.GetString(body));
        }
    }
}
