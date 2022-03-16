using Shared.RabbitMQ.Wrapper.Models;

namespace Processor.Models
{
    internal class BookProcessingRabbitMQOptions
    {
        public const string Key = "ImageProcessingOptions";
        public ScopeSettings ProducerSettings { get; set; } = default!;
        public ScopeSettings ConsumerSettings { get; set; } = default!;
    }
}
