using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Accounts.Service.UseCases.Model;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.GetAccountByUsername
{
    public class GetAccountByUsernameServiceRequest : IServiceRequest<AccountServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : AccountServiceHandler<GetAccountByUsernameServiceRequest, AccountServiceResponse>
        {
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public async override Task<AccountServiceResponse> Handle(GetAccountByUsernameServiceRequest request)
            {
                var account = await AccountContext.Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == request.Username);

                return Mapper.Map<AccountServiceResponse>(account);
            }
        }
    }
}