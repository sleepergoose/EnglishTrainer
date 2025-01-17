﻿using RabbitMQ.Client;

namespace Shared.RabbitMQ.Wrapper.Models
{
    internal class ConsumerSettings
    {
        public bool SequentialFetch { get; set; }

        public bool AutoAcknowledge { get; set; }

        public IModel Channel { get; set; }

        public string QueueName { get; set; }
    }
}
