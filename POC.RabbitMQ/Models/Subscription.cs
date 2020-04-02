using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.RabbitMQ.Models
{
    public class Subscription
    {
        public string Name { get; set; }

        public Type MessageType { get; set; }

        public List<Type> HandlerTypes { get; set; }

        public Subscription(string name, Type messagePayloadType)
        {
            Name = name;
            MessageType = messagePayloadType;
            HandlerTypes = new List<Type>();
        }

        public void AddHandlerType(Type handlerType)
        {
            if (!HandlerTypes.Any(type => type == handlerType))
            {
                HandlerTypes.Add(handlerType);
            }
        }
    }

    public class SubscriptionManager
    {
        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        public void AddSubscription(string name, Type messagePayloadType, Type handlerType)
        {
            var subscription = Subscriptions.FirstOrDefault(sub => sub.Name == name);

            if (subscription == null)
            {
                subscription = new Subscription(name, messagePayloadType);
                Subscriptions.Add(subscription);
            }

            subscription.AddHandlerType(handlerType);
        }

        public Subscription GetSubscriptionByName(string name)
        {
            return Subscriptions.FirstOrDefault(sub => sub.Name == name);
        }
    }
}
