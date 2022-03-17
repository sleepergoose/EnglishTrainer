using RabbitMQ.Client;
using Shared.RabbitMQ.Wrapper.Models;
using Shared.RabbitMQ.Wrapper.Interfaces;

namespace Shared.RabbitMQ.Wrapper.Services
{
    internal class ProducerScopeFactory : IProducerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProducerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IProducerScope Open(ScopeSettings messageScopeSettings)
        {
            return new ProducerScope(_connectionFactory, messageScopeSettings);
        }
    }
}
