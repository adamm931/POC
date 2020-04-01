using System;

namespace POC.RabbitMQ.Contracts
{
    public interface IMessageBus : IDisposable
    {
        void Subscribe<TMessage, THandler>()
            where TMessage : IMessagePayload
            where THandler : IMessageHandler<TMessage>;

        void Publish<TMessage>(TMessage message)
            where TMessage : IMessagePayload;
    }
}
