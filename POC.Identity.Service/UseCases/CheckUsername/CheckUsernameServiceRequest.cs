using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Models;
using POC.Identity.Service.UseCases.Base;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.CheckUsername
{
    public class CheckUsernameServiceRequest : IServiceRequest<CheckUsernameServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : IdentityServiceHandler<CheckUsernameServiceRequest, CheckUsernameServiceResponse>
        {
            public Handler(IIdentityApi identityApi, IMapping mapper) : base(identityApi, mapper)
            {
            }

            public override async Task<CheckUsernameServiceResponse> Handle(CheckUsernameServiceRequest request)
            {
                var apiRequest = Mapper.Map<CheckUsernameRequest>(request);

                var response = await IdentityApi.CheckUsernameAsync(apiRequest);

                return Mapper.Map<CheckUsernameServiceResponse>(response);
            }
        }

    }
}