using POC.RabbitMQ.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace POC.RabbitMQ.Extensions
{
    public static class BusMessageExtensions
    {
        public static string GetRoutingKey(this Type type)
        {
            return GetMessageNamespace(type)?.RoutingKey;
        }

        private static MessageNamespaceAttribute GetMessageNamespace(Type type)
        {
            var messageNamespaceAttributes = type
                            .GetCustomAttributes()
                            .OfType<MessageNamespaceAttribute>();

            if (!messageNamespaceAttributes.Any())
            {
                return null;
            }

            return messageNamespaceAttributes.First();
        }
    }
}
