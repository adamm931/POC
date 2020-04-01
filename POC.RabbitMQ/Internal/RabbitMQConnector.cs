using POC.RabbitMQ.Contracts;
using RabbitMQ.Client;
using System;

namespace POC.RabbitMQ.Internal
{
    internal class RabbitMQConnector : IRabbitMQConnector
    {
        private readonly IConnectionFactory _connectionFactory;

        private IConnection _connection;

        private bool _disposed;

        public RabbitMQConnector(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool IsConnected => _connection?.IsOpen ?? false;

        public void EnsureConnected()
        {
            if (!IsConnected)
            {
                _connection = _connectionFactory.CreateConnection();
            }
        }

        public IModel GetChannel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Channel is not connected, first call Connect() method");
            }

            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (_connection == null || _connection.IsOpen)
            {
                return;
            }

            _connection.Dispose();
            _disposed = true;
        }
    }
}
