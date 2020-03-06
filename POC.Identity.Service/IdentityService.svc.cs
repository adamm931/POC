using POC.Identity.Models;
using POC.Identity.Providers;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.Models;
using System;
using System.Threading.Tasks;

namespace POC.Identity.Service
{
    internal class IdentityService : IIdentityService
    {
        public async Task<ServiceResponse<CheckUsernameServiceResponse>> CheckUsernameAsync(CheckUsernameServiceRequest serviceRequest)
        {
            try
            {
                var userService = UserServiceProvider.GetUserService();

                var request = new CheckUsernameRequest
                {
                    Username = serviceRequest.Username
                };

                var response = await userService.CheckUsernameAsync(request);

                var serviceReponse = new CheckUsernameServiceResponse
                {
                    IsAvailable = response.IsAvailable
                };

                return ServiceResponse<CheckUsernameServiceResponse>.Success(serviceReponse);
            }

            catch (Exception exception)
            {
                return ServiceResponse<CheckUsernameServiceResponse>.Fail(exception);
            }
        }

        public async Task<ServiceResponse<UserLoginServiceResponse>> LoginAsync(UserLoginServiceRequest serviceRequest)
        {
            try
            {
                var userService = UserServiceProvider.GetUserService();

                var request = new UserLoginRequest
                {
                    Username = serviceRequest.Username,
                    Password = serviceRequest.Password
                };

                var response = await userService.LoginAsync(request);

                var serviceReponse = new UserLoginServiceResponse
                {
                    IsAuthenticated = response.IsAuthenticated
                };

                return ServiceResponse<UserLoginServiceResponse>.Success(serviceReponse);
            }

            catch (Exception e)
            {
                return ServiceResponse<UserLoginServiceResponse>.Fail(e);
            }
        }

        public async Task<ServiceResponse> SignupAsync(SignupUserServiceRequest serviceRequest)
        {
            try
            {
                var userService = UserServiceProvider.GetUserService();

                var request = new SignupUserRequest
                {
                    Username = serviceRequest.Username,
                    Password = serviceRequest.Password
                };

                await userService.SignupAsync(request);

                return ServiceResponse.Success();
            }

            catch (Exception exception)
            {
                return ServiceResponse.Fail(exception);
            }
        }
    }
}
