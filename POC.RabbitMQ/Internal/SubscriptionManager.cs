using POC.RabbitMQ.Contracts;

namespace POC.RabbitMQ.Internal
{
    public class SubscriptionManager : ISubscriptionManager
    {
        private readonly IMessageBus _bus;

        public SubscriptionManager(IMessageBus bus)
        {
            _bus = bus;
        }
        public void Subscribe<TMessage, THandler>()
            where TMessage : IMessagePayload
            where THandler : IMessageHandler<TMessage>
        {
            _bus.Subscribe<TMessage, THandler>();
        }
    }
}
