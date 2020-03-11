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
        Task<ServiceResponse> UpdateAccountHeaderAsync(AccountHeaderServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> UpdateAccountAddressAsync(AccountAddressServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse<AccountServiceResponse>> GetAccountAsync(Guid id);

        [OperationContract]
        Task<ServiceResponse<AccountServiceResponse>> GetAccountByUsername(string username);

        [OperationContract]
        Task<ServiceResponse<AccountLoginServiceResponse>> AddAccountLoginAsync(AccountLoginServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse<UpdateAccountLoginServiceResponse>> UpdateAccountLoginAsync(UpdateAccountLoginServiceRequest serviceRequest);
    }
}
