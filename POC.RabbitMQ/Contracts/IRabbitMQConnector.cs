using RabbitMQ.Client;
using System;

namespace POC.RabbitMQ.Contracts
{
    public interface IRabbitMQConnector : IDisposable
    {
        bool IsConnected { get; }

        void EnsureConnected();

        IModel GetChannel();
    }
}
