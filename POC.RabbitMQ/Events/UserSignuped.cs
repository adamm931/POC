using POC.RabbitMQ.Attributes;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Models;

namespace POC.RabbitMQ.Events
{
    [MessageNamespace(RoutesKeys.UserSignuped)]
    public class UserSignuped : BusMessage
    {
        public UserSignuped(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}