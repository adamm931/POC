using POC.RabbitMQ.Attributes;
using POC.RabbitMQ.Common;
using POC.RabbitMQ.Contracts;

namespace POC.RabbitMQ.Events
{
    [MessageNamespace(RoutesKeys.UserUpdated)]
    public class UserUpdated : IMessagePayload
    {
        public UserUpdated(string oldUsername, string newUsername)
        {
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }

        public string OldUsername { get; set; }

        public string NewUsername { get; set; }
    }
}