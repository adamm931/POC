using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Models;
using POC.Identity.Service.UseCases.Base;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Login
{
    public class UserLoginServiceRequest : IServiceRequest<UserLoginServiceResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<UserLoginServiceRequest, UserLoginServiceResponse>
        {
            public Handler(IIdentityApi identityApi, IMapping mapper) : base(identityApi, mapper)
            {
            }

            public override async Task<UserLoginServiceResponse> Handle(UserLoginServiceRequest request)
            {
                var apiRequest = Mapper.Map<UserLoginRequest>(request);

                var response = await IdentityApi.LoginAsync(apiRequest);

                return Mapper.Map<UserLoginServiceResponse>(response);
            }
        }
    }
}