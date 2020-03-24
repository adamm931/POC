using POC.MQ;

namespace POC.Identity.Service.Events
{
    public class UserUpdated : BusMessage
    {
        public UserUpdated(string oldUsername, string newUsername) : base(nameof(UserUpdated), nameof(Identity))
        {
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }

        public string OldUsername { get; set; }

        public string NewUsername { get; set; }
    }
}