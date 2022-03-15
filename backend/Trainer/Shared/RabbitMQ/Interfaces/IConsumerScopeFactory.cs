using Shared.RabbitMQ.Wrapper.Models;

namespace Shared.RabbitMQ.Wrapper.Interfaces
{
    public interface IConsumerScopeFactory
    {
        IConsumerScope Open(ScopeSettings scopeSettings);

        IConsumerScope Connect(ScopeSettings scopeSettings);
    }
}
