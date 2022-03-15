using RabbitMQ.Client;
using Shared.RabbitMQ.Wrapper.Models;
using Shared.RabbitMQ.Wrapper.Interfaces;

namespace Shared.RabbitMQ.Wrapper.Services
{
    internal class ConsumerScopeFactory : IConsumerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public ConsumerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IConsumerScope Open(ScopeSettings ScopeSettings)
        {
            return new ConsumerScope(_connectionFactory, ScopeSettings);
        }

        public IConsumerScope Connect(ScopeSettings ScopeSettings)
        {
            var ConsumerScope = Open(ScopeSettings);
            ConsumerScope.Consumer.Connect();

            return ConsumerScope;
        }
    }
}
