using POC.Common.Service;
using POC.Identity.Service.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Identity.Service.Contracts
{
    [ServiceContract]
    public interface IIdentityService
    {
        [OperationContract]
        Task<ServiceResponse<UserLoginServiceResponse>> LoginAsync(UserLoginServiceRequest request);

        [OperationContract]
        Task<ServiceResponse> UpdateLoginAsync(UpdateUserLoginServiceRequest request);

        [OperationContract]
        Task<ServiceResponse> SignupAsync(SignupUserServiceRequest request);

        [OperationContract]
        Task<ServiceResponse<CheckUsernameServiceResponse>> CheckUsernameAsync(CheckUsernameServiceRequest request);
    }
}
