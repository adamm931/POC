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
                return ServiceResponse<UserLoginServiceResponse>.Fail(e.ToString());
            }
        }
    }
}
