using POC.Configuration.DI;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.DI;
using POC.RabbitMQ.Events;
using System;

namespace POC.RabbitMQ.Publisher
{
    class Program
    {
        static void Main()
        {
            ContainerProvider.Container.RegisterRabbitMQ();

            var bus = ContainerProvider.Container.Resolve<IMessageBus>();

            while (true)
            {
                Console.WriteLine("Enter message to publish, to exit the app press 'x'");
                var message = Console.ReadLine();

                bus.Publish(new UserSignuped(message));

                if (message == "x")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
