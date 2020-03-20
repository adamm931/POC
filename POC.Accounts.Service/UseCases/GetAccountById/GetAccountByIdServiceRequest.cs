using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Accounts.Service.UseCases.Model;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.GetAccountById
{
    public class GetAccountByIdServiceRequest : IServiceRequest<AccountServiceResponse>
    {
        public Guid Id { get; set; }

        public class Handler : AccountServiceHandler<GetAccountByIdServiceRequest, AccountServiceResponse>
        {
            public Handler(IAccountApi accountApi, IMapping mapper) : base(accountApi, mapper)
            {
            }

            public override async Task<AccountServiceResponse> Handle(GetAccountByIdServiceRequest request)
            {
                var account = await AccountApi.GetAccountAsync(request.Id);

                return Mapper.Map<AccountServiceResponse>(account);
            }
        }
    }
}