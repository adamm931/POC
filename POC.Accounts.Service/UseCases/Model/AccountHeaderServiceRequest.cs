using POC.Common.Service;
using System;

namespace POC.Accounts.Service.UseCases.Model
{
    public class AccountHeaderServiceRequest : IServiceRequest
    {
        public string AccountUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
