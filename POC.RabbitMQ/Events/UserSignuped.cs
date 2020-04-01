using POC.RabbitMQ.Attributes;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Contracts;

namespace POC.RabbitMQ.Events
{
    [MessageNamespace(RoutesKeys.UserSignuped)]
    public class UserSignuped : IMessagePayload
    {
        public UserSignuped(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}