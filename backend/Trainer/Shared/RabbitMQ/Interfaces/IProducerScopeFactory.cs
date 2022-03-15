using Shared.RabbitMQ.Wrapper.Models;

namespace Shared.RabbitMQ.Wrapper.Interfaces
{
    public interface IProducerScopeFactory
    {
        IProducerScope Open(ScopeSettings scopeSettings);
    }
}
