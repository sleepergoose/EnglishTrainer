using System;
using RabbitMQ.Client.Events;
using Shared.RabbitMQ.Wrapper.Models;
using Shared.RabbitMQ.Wrapper.Services;

namespace Shared.RabbitMQ.Wrapper.Interfaces
{
    public interface IMessageService
    {
        event MessageService.MessageDelegate MessageReceived;

        void SetMessageService(ScopeSettings producerSettings, ScopeSettings consumerSettings);

        void SendDataToQueue(byte[] body);

        void ListenQueue(Object model, BasicDeliverEventArgs ea);

        void Dispose();
    }
}
