using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Threading.Tasks;

namespace POC.Accounts.Service.Model
{
    public class AddAccountLoginServiceRequest : IServiceRequest<AddAccountLoginServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : AccountServiceHandler<AddAccountLoginServiceRequest, AddAccountLoginServiceResponse>
        {
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public override async Task<AddAccountLoginServiceResponse> Handle(AddAccountLoginServiceRequest request)
            {
                var accountLogin = AccountLogin.CreateAndInitializeAccount(request.Username);

                AccountContext.AccountLogins.Add(accountLogin);

                await AccountContext.Save();

                return Mapper.Map<AddAccountLoginServiceResponse>(accountLogin);
            }
        }
    }
}
