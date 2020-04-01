using POC.Common;
using POC.RabbitMQ.Contracts;
using System;

namespace POC.RabbitMQ.Extensions
{
    internal static class MessageBusExtensions
    {
        internal static void LoadConfigurationFromAssembly(this IMessageBus messageBus, Type assemblyType)
        {
            var configurators = assemblyType.Assembly
                .GetInstancesOf<IMessageBusConfigurator>();

            foreach (var busConfigurator in configurators)
            {
                busConfigurator.Configure(messageBus);
            }
        }
    }
}
