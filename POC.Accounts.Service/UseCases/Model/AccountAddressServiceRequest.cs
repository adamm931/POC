using POC.Common.Service;

namespace POC.Accounts.Service.UseCases.Model
{
    public class AccountAddressServiceRequest : IServiceRequest
    {
        public string AccountUsername { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
