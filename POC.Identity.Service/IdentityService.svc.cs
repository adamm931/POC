using POC.Common.Mapper;
using POC.Common.Service;
using POC.Identity.Contracts;
using POC.Identity.Models;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.MappingProfiles;
using POC.Identity.Service.Models;
using System.Threading.Tasks;

namespace POC.Identity.Service
{
    internal class IdentityService : IIdentityService
    {
        private readonly Mapping Mapping = Mapping.Create(new IdentityServiceMappingProfile());

        private readonly IIdentityApi UserService = new IdentityApi();

        public async Task<ServiceResponse<CheckUsernameServiceResponse>> CheckUsernameAsync(CheckUsernameServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<CheckUsernameRequest>(serviceRequest);

                var response = await UserService.CheckUsernameAsync(request);

                return Mapping.Map<CheckUsernameServiceResponse>(response);
            });
        }

        public async Task<ServiceResponse<UserLoginServiceResponse>> LoginAsync(UserLoginServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<UserLoginRequest>(serviceRequest);

                var response = await UserService.LoginAsync(request);

                return Mapping.Map<UserLoginServiceResponse>(response);
            });
        }

        public async Task<ServiceResponse> SignupAsync(SignupUserServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<SignupUserRequest>(serviceRequest);

                await UserService.SignupAsync(request);
            });
        }

        public async Task<ServiceResponse> UpdateLoginAsync(UpdateUserLoginServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<UpdateUserLoginRequest>(serviceRequest);

                await UserService.UpdateLoginAsync(request);
            });
        }
    }
}
