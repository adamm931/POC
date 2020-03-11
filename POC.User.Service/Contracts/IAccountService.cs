using POC.Accounts.Service.Model;
using POC.Common.Service;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Accounts.Service.Contracts
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        Task<ServiceResponse> UpdateAccountHeaderAsync(AccountHeaderServiceRequest ServiceRequest);

        [OperationContract]
        Task<ServiceResponse> UpdateAccountAddressAsync(AccountAddressServiceRequest ServiceRequest);

        [OperationContract]
        Task<ServiceResponse<AccountServiceResponse>> GetAccountAsync(Guid id);

        [OperationContract]
        Task<ServiceResponse<AccountLoginServiceResponse>> AddAccountLoginAsync(AccountLoginServiceRequest ServiceRequest);

        [OperationContract]
        Task<ServiceResponse<UpdateAccountLoginServiceResponse>> UpdateAccountLoginAsync(UpdateAccountLoginServiceRequest ServiceRequest);
    }
}
