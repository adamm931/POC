using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Models;
using POC.Identity.Service.UseCases.Base;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Signup
{
    public class SignupUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<SignupUserServiceRequest>
        {
            public Handler(IIdentityApi identityApi, IMapping mapper) : base(identityApi, mapper)
            {
            }

            public override async Task Handle(SignupUserServiceRequest request)
            {
                var apiRequest = Mapper.Map<SignupUserRequest>(request);

                await IdentityApi.SignupAsync(apiRequest);
            }
        }
    }
}