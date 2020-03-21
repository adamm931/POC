using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Service.Model
{
    public class UpdateAccountLoginServiceRequest : IServiceRequest<UpdateAccountLoginServiceResponse>
    {
        public string AccountUsername { get; set; }

        public string AccountNewUsername { get; set; }

        public class Handler : AccountServiceHandler<UpdateAccountLoginServiceRequest, UpdateAccountLoginServiceResponse>
        {
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public async override Task<UpdateAccountLoginServiceResponse> Handle(UpdateAccountLoginServiceRequest request)
            {
                await CheckUsername(request.AccountNewUsername);

                var account = await GetAccount(request.AccountUsername);

                account.UpdateLogin(request.AccountNewUsername);

                await AccountContext.Save();

                return Mapper.Map<UpdateAccountLoginServiceResponse>(account.Login);
            }

            private async Task<Account> GetAccount(string accountUsername)
            {
                return await AccountContext.Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == accountUsername);
            }

            private async Task CheckUsername(string accountNewUsername)
            {
                var exists = await AccountContext.AccountLogins
                    .AnyAsync(login => login.Username == accountNewUsername);

                if (exists)
                {
                    throw new InvalidOperationException($"Username: {accountNewUsername} is not available");
                }
            }
        }
    }
}
