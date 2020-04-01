using POC.Common.Service;
using POC.Common.Service.Factory;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.UseCases.CheckUsername;
using POC.Identity.Service.UseCases.Login;
using POC.Identity.Service.UseCases.Signup;
using POC.Identity.Service.UseCases.UpdateLogin;
using System.Threading.Tasks;

namespace POC.Identity.Service
{
    internal class IdentityService : IIdentityService
    {
        private readonly IServiceMediator _serviceMediator = ServiceMediatorFactory.CreateMediator();

        public async Task<ServiceResponse<CheckUsernameServiceResponse>> CheckUsernameAsync(CheckUsernameServiceRequest serviceRequest)
            => await _serviceMediator.Handle<CheckUsernameServiceRequest, CheckUsernameServiceResponse>(serviceRequest);

        public async Task<ServiceResponse<UserLoginServiceResponse>> LoginAsync(UserLoginServiceRequest serviceRequest)
            => await _serviceMediator.Handle<UserLoginServiceRequest, UserLoginServiceResponse>(serviceRequest);

        public async Task<ServiceResponse> SignupAsync(SignupUserServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> UpdateLoginAsync(UpdateUserLoginServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);
    }
}
