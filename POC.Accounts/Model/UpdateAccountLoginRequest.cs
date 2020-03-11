using System;

namespace POC.Accounts.Model
{
    public class UpdateAccountLoginRequest
    {
        public Guid AccountId { get; set; }

        public string Username { get; set; }
    }
}
