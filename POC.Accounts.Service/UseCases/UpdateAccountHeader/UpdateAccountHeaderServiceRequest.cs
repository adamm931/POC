using POC.Accounts.Contracts;
using POC.Accounts.Model;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.UpdateAccountHeader
{
    public class UpdateAccountHeaderServiceRequest : IServiceRequest
    {
        public string AccountUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public class Handler : AccountServiceHandler<UpdateAccountHeaderServiceRequest>
        {
            public Handler(IAccountApi accountApi, IMapping mapper) : base(accountApi, mapper)
            {
            }

            public async override Task Handle(UpdateAccountHeaderServiceRequest request)
            {
                var apiRequest = Mapper.Map<AccountHeaderRequest>(request);

                await AccountApi.UpdateAccountHeaderAsync(apiRequest);
            }
        }
    }
}