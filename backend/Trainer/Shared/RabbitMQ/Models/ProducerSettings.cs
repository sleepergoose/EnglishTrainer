using RabbitMQ.Client;
using Shared.RabbitMQ.Wrapper.Interfaces;

namespace Shared.RabbitMQ.Wrapper.Models
{
    internal class ProducerSettings
    {
        public IModel Channel { get; set; }
        public PublicationAddress PublicationAddress { get; set; }
    }
}
