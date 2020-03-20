using POC.Accounts.Contracts;
using POC.Accounts.Model;
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
            public Handler(IAccountApi accountApi, IMapping mapper) : base(accountApi, mapper)
            {
            }

            public override async Task<AddAccountLoginServiceResponse> Handle(AddAccountLoginServiceRequest request)
            {
                var addLoginRequest = Mapper.Map<AccountLoginRequest>(request);

                var addLoginResponse = await AccountApi.AddAccountLoginAsync(addLoginRequest);

                return Mapper.Map<AddAccountLoginServiceResponse>(addLoginResponse);
            }
        }
    }
}
