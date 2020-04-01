using System;

namespace POC.RabbitMQ.Attributes
{
    public class MessageNamespaceAttribute : Attribute
    {
        public string RoutingKey { get; }

        public MessageNamespaceAttribute(string routingKey)
        {
            RoutingKey = routingKey;
        }
    }
}
