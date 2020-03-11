using System;

namespace POC.Accounts.Service.Model
{
    public class UpdateAccountLoginServiceRequest
    {
        public Guid AccountId { get; set; }

        public string Username { get; set; }
    }
}
