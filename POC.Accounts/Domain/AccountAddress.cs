using POC.Common.Domain;

namespace POC.Accounts.Domain
{
    public class AccountAddress : Entity
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string ZipCode { get; private set; }

        public string Region { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public Account Account { get; private set; }

        public AccountAddress(string street, string city, string zipCode, string region, string phone, string email)
        {
            Update(street, city, zipCode, region, phone, email);
        }

        internal AccountAddress() { }

        public void UpdateAddress(string street, string city, string zipCode, string region, string phone, string email)
        {
            Update(street, city, zipCode, region, phone, email);
        }

        private void Update(string street, string city, string zipCode, string region, string phone, string email)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            Region = region;
            Phone = phone;
            Email = email;
        }
    }
}
