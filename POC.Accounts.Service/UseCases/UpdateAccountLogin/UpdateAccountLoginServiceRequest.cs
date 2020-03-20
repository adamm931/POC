using POC.Accounts.Contracts;
using POC.Accounts.Model;
using POC.Accounts.Service.UseCases.Base;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Threading.Tasks;

namespace POC.Accounts.Service.Model
{
    public class UpdateAccountLoginServiceRequest : IServiceRequest<UpdateAccountLoginServiceResponse>
    {
        public string AccountUsername { get; set; }

        public string AccountNewUsername { get; set; }

        public class Handler : AccountServiceHandler<UpdateAccountLoginServiceRequest, UpdateAccountLoginServiceResponse>
        {
            public Handler(IAccountApi accountApi, IMapping mapper) : base(accountApi, mapper)
            {
            }

            public async override Task<UpdateAccountLoginServiceResponse> Handle(UpdateAccountLoginServiceRequest request)
            {
                var updateLoginRequest = Mapper.Map<UpdateAccountLoginRequest>(request);

                var updateLoginResponse = await AccountApi.UpdateAccountLoginAsync(updateLoginRequest);

                return Mapper.Map<UpdateAccountLoginServiceResponse>(updateLoginResponse);
            }
        }
    }
}
