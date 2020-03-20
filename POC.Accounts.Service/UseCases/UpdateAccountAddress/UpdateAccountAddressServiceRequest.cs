using POC.Accounts.Contracts;
using POC.Accounts.Model;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.UpdateAccountAddress
{
    public class UpdateAccountAddressServiceRequest : IServiceRequest
    {
        public string AccountUsername { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public class Handler : AccountServiceHandler<UpdateAccountAddressServiceRequest>
        {
            public Handler(IAccountApi accountApi, IMapping mapper) : base(accountApi, mapper)
            {
            }

            public override async Task Handle(UpdateAccountAddressServiceRequest request)
            {
                var apiRequest = Mapper.Map<AccountAddressRequest>(request);

                await AccountApi.UpdateAccountAddressAsync(apiRequest);
            }
        }

    }
}