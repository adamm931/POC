using Newtonsoft.Json;
using POC.Configuration.DI;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Extensions;
using POC.RabbitMQ.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace POC.RabbitMQ.Internal
{
    public class RabbitMQBus : IMessageBus
    {
        private readonly IRabbitMQConnector _channelConnector;

        private readonly BusOptions _busOptions;

        private readonly IContainer _container;

        private readonly string _exchange = Exchanges.Default;

        private readonly IModel _channel;

        private static readonly SubscriptionManager _subscriptionManager = new SubscriptionManager();

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
            where TMessage : BusMessage
        {
            _channelConnector.EnsureConnected();

            using (var channel = _channelConnector.GetChannel())
            {
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = DeliveryMode.Persistant;

                channel.BasicPublish(
                    exchange: _exchange,
                    routingKey: GetRoutingKey<TMessage>(),
                    basicProperties: props,
                    body: message.GetBytes());
            }
        }

        public void Subscribe<TMessage, THandler>()
            where TMessage : BusMessage
            where THandler : IMessageHandler<TMessage>
        {
            var routingKey = GetRoutingKey<TMessage>();

            // add subscription
            _subscriptionManager.AddSubscription(routingKey, typeof(TMessage), typeof(THandler));

            // start consume
            StartConsuming(routingKey);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        private void OnMessageRecieved(object sender, BasicDeliverEventArgs args)
        {
            var subscription = _subscriptionManager.GetSubscriptionByName(
                name: args.RoutingKey);

            foreach (var handlerType in subscription.HandlerTypes)
            {
                var argsBody = Encoding.UTF8.GetString(args.Body);
                var message = JsonConvert.DeserializeObject(argsBody, subscription.MessageType);
                var handler = _container.RegisterThanResolve(handlerType);

                var task = (Task)handler.GetType()
                    .GetMethod("HandleAsync")
                    .Invoke(handler, new[] { message });

                task.Wait();
            }
        }

        private void StartConsuming(string routingKey)
        {
            _channel.QueueBind(
                queue: _busOptions.Client,
                exchange: _exchange,
                routingKey: routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageRecieved;

            _channel.BasicConsume(
                queue: _busOptions.Client,
                autoAck: true,
                consumer: consumer);
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
