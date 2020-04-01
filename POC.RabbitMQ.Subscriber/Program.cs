using POC.Configuration.DI;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.DI;
using POC.RabbitMQ.Events;
using System;
using System.Threading.Tasks;

namespace POC.RabbitMQ.Subscriber
{
    class Program
    {
        static void Main()
        {
            ContainerProvider.Container.RegisterRabbitMQ();

            var bus = ContainerProvider.Container.Resolve<IMessageBus>();

            bus.Subscribe<UserSignuped, PrintToConsoleUsernameHandler>();

            Console.WriteLine("Display messages here");
            Console.ReadKey();
        }
    }

    public class PrintToConsoleUsernameHandler : IMessageHandler<UserSignuped>
    {
        public async Task HandleAsync(UserSignuped message)
        {
            if (message.Username == "x")
            {
                Environment.Exit(0);
            }

            Console.WriteLine(message.Username);
        }
    }
}
