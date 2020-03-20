using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Models;
using POC.Identity.Service.UseCases.Base;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.UpdateLogin
{
    public class UpdateUserLoginServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string NewUsername { get; set; }

        public string NewPassword { get; set; }

        public class Handler : IdentityServiceHandler<UpdateUserLoginServiceRequest>
        {
            public Handler(IIdentityApi identityApi, IMapping mapper) : base(identityApi, mapper)
            {
            }

            public override async Task Handle(UpdateUserLoginServiceRequest request)
            {
                var apiRequest = Mapper.Map<UpdateUserLoginRequest>(request);

                await IdentityApi.UpdateLoginAsync(apiRequest);
            }
        }
    }
}