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
    }
}
