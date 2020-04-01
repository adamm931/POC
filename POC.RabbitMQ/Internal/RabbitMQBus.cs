using POC.Configuration.DI;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace POC.RabbitMQ.Internal
{
    public class RabbitMQBus : IMessageBus
    {
        private readonly IRabbitMQConnector _channelConnector;

        private readonly BusOptions _busOptions;

        private readonly IContainer _container;

        private readonly string _exchange = Exchanges.Default;

        private readonly IModel _channel;

        public RabbitMQBus(
            IRabbitMQConnector connector,
            BusOptions busOptions,
            IContainer container)
        {
            _channelConnector = connector;
            _busOptions = busOptions;
            _container = container;
            _channel = CreateChannel();
        }

        public void Publish<TMessage>(TMessage message)
            where TMessage : IMessagePayload
        {
            var props = _channel.CreateBasicProperties();
            props.DeliveryMode = DeliveryMode.Persistant;

            var body = new BusMessage<TMessage>(message);

            _channel.BasicPublish(
                exchange: _exchange,
                routingKey: GetRoutingKey<TMessage>(),
                basicProperties: props,
                body: body.GetBytes());
        }

        public void Subscribe<TMessage, THandler>()
            where TMessage : IMessagePayload
            where THandler : IMessageHandler<TMessage>
        {
            _channel.QueueBind(
                queue: _busOptions.Client,
                exchange: _exchange,
                routingKey: GetRoutingKey<TMessage>());

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageRecieved<TMessage, THandler>;

            _channel.BasicConsume(
                queue: _busOptions.Client,
                autoAck: false,
                consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        private void OnMessageRecieved<TMessage, THandler>(object sender, BasicDeliverEventArgs args)
            where TMessage : IMessagePayload
            where THandler : IMessageHandler<TMessage>
        {
            var message = BusMessage<TMessage>.FromBytes(args.Body);

            _container
                .RegisterThanResolve<THandler>()
                .HandleAsync(message.Payload)
                .Wait();

            _channel.BasicAck(args.DeliveryTag, false);
        }

        private IModel CreateChannel()
        {
            _channelConnector.EnsureConnected();
            var channel = _channelConnector.GetChannel();

            channel.QueueDeclare(
                queue: _busOptions.Client,
                durable: true,
                exclusive: false,
                autoDelete: false);

            channel.ExchangeDeclare(
                exchange: _exchange,
                type: ExchangeType.Direct);

            return channel;
        }

        private static string GetRoutingKey<TMessage>()
        {
            return typeof(TMessage).GetRoutingKey() ?? typeof(TMessage).Name;
        }
    }
}
