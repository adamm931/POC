using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Data.Entity;
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
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public override async Task Handle(UpdateAccountAddressServiceRequest request)
            {
                var account = await AccountConext.Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == request.AccountUsername);

                account.UpdatetAddress(
                    request.Street,
                    request.City,
                    request.ZipCode,
                    request.Region,
                    request.Phone,
                    request.Email);

                await AccountConext.Save();
            }
        }

    }
}