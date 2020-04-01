using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using POC.Todos.Service.MessageHandlers;

namespace POC.Todos.Service.MessageBusConfigurator
{
    public class TodosServiceMessageBusConfigurator : IMessageBusConfigurator
    {
        public void Configure(IMessageBus messageBus)
        {
            messageBus.Subscribe<UserUpdated, UserUpdatedMessageHandler>();
            messageBus.Subscribe<UserSignuped, UserSignupedMessageHandler>();
        }
    }
}