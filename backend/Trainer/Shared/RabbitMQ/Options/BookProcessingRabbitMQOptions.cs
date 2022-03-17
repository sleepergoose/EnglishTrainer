using Shared.RabbitMQ.Wrapper.Models;

namespace Shared.RabbitMQ.Wrapper.Options
{
    public class BookProcessingRabbitMQOptions
    {
        public const string Key = "BookProcessingOptions";
        public ScopeSettings ProducerSettings { get; set; } = default!;
        public ScopeSettings ConsumerSettings { get; set; } = default!;
    }
}
