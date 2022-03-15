﻿namespace Shared.RabbitMQ.Wrapper.Interfaces
{
    public interface IProducerScope
    {
        IProducer Producer { get; }
        void Dispose();
    }
}
