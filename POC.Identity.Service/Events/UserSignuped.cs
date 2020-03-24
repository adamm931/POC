using POC.MQ;

namespace POC.Identity.Service.Events
{
    public class UserSignuped : BusMessage
    {
        public string Username { get; set; }

        public UserSignuped(string username) : base(nameof(UserSignuped), nameof(Identity))
        {
            Username = username;
        }
    }
}