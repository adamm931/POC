using POC.Configuration.DI;
using POC.MQ.Contracts;
using POC.MQ.Internal;
using RabbitMQ.Client;

namespace POC.MQ.DI
{
    public static class DIContainerExtensions
    {
        public static void RegisterPocMQ(this IContainer container)
        {
            container.RegisterInstance(GetRabbitClient());
            container.Register<IBusPublisher, BusPublisher>();
            container.Register<IBusConsumer, BusConsumer>();
        }

        private static IModel GetRabbitClient()
        {
            return new ConnectionFactory
            {
                HostName = "172.31.142.52", //this will be container ip address
                Port = 5672, // this will be container port
                UserName = ConnectionFactory.DefaultUser,
                Password = ConnectionFactory.DefaultPass
            }
            .CreateConnection()
            .CreateModel();
        }
    }
}
