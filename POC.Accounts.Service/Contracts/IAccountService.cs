using POC.Accounts.Service.Model;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.UpdateAccountAddress;
using POC.Accounts.Service.UseCases.UpdateAccountHeader;
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
        Task<ServiceResponse> UpdateAccountHeaderAsync(UpdateAccountHeaderServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> UpdateAccountAddressAsync(UpdateAccountAddressServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse<AccountServiceResponse>> GetAccountByIdAsync(Guid id);

        [OperationContract]
        Task<ServiceResponse<AccountServiceResponse>> GetAccountByUsernameAsync(string username);

        [OperationContract]
        Task<ServiceResponse<AddAccountLoginServiceResponse>> AddAccountLoginAsync(AddAccountLoginServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse<UpdateAccountLoginServiceResponse>> UpdateAccountLoginAsync(UpdateAccountLoginServiceRequest serviceRequest);
    }
}
