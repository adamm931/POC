namespace POC.RabbitMQ.Contracts
{
    public interface ISubscriptionManager
    {
        void Subscribe<TMessage, THandler>()
           where TMessage : IMessagePayload
           where THandler : IMessageHandler<TMessage>;
    }
}
