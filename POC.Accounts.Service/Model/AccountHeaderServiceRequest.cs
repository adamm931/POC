using System;

namespace POC.Accounts.Service.Model
{
    public class AccountHeaderServiceRequest
    {
        public string AccountUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
