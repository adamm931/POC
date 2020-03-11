using System;

namespace POC.Accounts.Model
{
    public class AccountResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public AccountAddressResponse Address { get; set; }
    }
}
