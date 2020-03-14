using System;

namespace POC.Accounts.Model
{
    public class AccountHeaderRequest
    {
        public string AccountUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
