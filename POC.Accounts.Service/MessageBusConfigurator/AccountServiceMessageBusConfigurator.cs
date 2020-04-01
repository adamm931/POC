using POC.Accounts.Service.MessageHandlers;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;

namespace POC.Accounts.Service.MessageBusConfigurator
{
    public class AccountServiceMessageBusConfigurator : IMessageBusConfigurator
    {
        public void Configure(IMessageBus messageBus)
        {
            messageBus.Subscribe<UserUpdated, UserUpdatedMessageHandler>();
            messageBus.Subscribe<UserSignuped, UserSignupedMessageHandler>();
        }
    }
}