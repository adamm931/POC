using POC.MQ.Common;
using POC.MQ.Contracts;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace POC.MQ.Internal
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IModel _rabitMQ;

        public BusPublisher(IModel rabbitMQClient)
        {
            _rabitMQ = rabbitMQClient;

        }
        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : BusMessage
        {
            BindMessageExchangeToQueue(message);

            var props = _rabitMQ.CreateBasicProperties();

            props.DeliveryMode = 2;

            await Task.Run(() => _rabitMQ.BasicPublish(
                    exchange: message.Exchange, routingKey: message.RouteKey, basicProperties: props, body: message.GetBytes()));
        }

        private void BindMessageExchangeToQueue<TMessage>(TMessage message) where TMessage : BusMessage
        {
            _rabitMQ.QueueDeclare(
               queue: QueueNames.Poc, durable: false, exclusive: false);

            _rabitMQ.ExchangeDeclare(
                exchange: message.Exchange, type: "direct");

            _rabitMQ.QueueBind(
                queue: QueueNames.Poc, exchange: message.Exchange, routingKey: message.RouteKey);
        }
    }
}
