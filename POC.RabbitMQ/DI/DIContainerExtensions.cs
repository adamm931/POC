using POC.Common;
using POC.Common.Enviroment;
using POC.Configuration.DI;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Internal;
using RabbitMQ.Client;
using System;

namespace POC.RabbitMQ.DI
{
    public static class DIContainerExtensions
    {
        public static void RegisterRabbitMQ(
            this IContainer container,
            Action<BusOptions> options = null,
            Type configuratorAssemblyType = null)
        {
            container.RegisterConnectionFactory();
            container.RegisterBusOptions(options);
            container.RegisterSingleton<IRabbitMQConnector, RabbitMQConnector>();
            container.RegisterSingleton<IMessageBus, RabbitMQBus>();
            container.ConfigureMessageBus(configuratorAssemblyType);
        }

        private static void RegisterConnectionFactory(this IContainer container)
        {
            container.RegisterInstance<IConnectionFactory>(new ConnectionFactory
            {
                HostName = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.RabbitMQHost),
                Port = EnviromentVariablesFetcher.GetVaraiable<int>(EnviromentVariables.RabbitMQPort),
                UserName = ConnectionFactory.DefaultUser,
                Password = ConnectionFactory.DefaultPass
            });
        }

        private static void RegisterBusOptions(this IContainer container, Action<BusOptions> busOptionsSetup)
        {
            var busOptions = new BusOptions();

            busOptionsSetup?.Invoke(busOptions);

            busOptions.Client = busOptions.Client ?? Queues.Default;

            container.RegisterInstance(busOptions);
        }

        private static void ConfigureMessageBus(this IContainer container, Type configuratorAssemblyType)
        {
            if (configuratorAssemblyType == null)
            {
                return;
            }

            var messageBus = container.Resolve<IMessageBus>();

            var configurators = configuratorAssemblyType.Assembly
               .GetInstancesOf<IMessageBusConfigurator>();

            foreach (var busConfigurator in configurators)
            {
                busConfigurator.Configure(messageBus);
            }
        }
    }
}
