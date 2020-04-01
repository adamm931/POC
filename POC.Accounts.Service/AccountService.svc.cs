using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.UseCases.GetAccountById;
using POC.Accounts.Service.UseCases.GetAccountByUsername;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.UpdateAccountAddress;
using POC.Accounts.Service.UseCases.UpdateAccountHeader;
using POC.Common.Service;
using POC.Common.Service.Factory;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service
{
    public class AccountService : IAccountService
    {
        private readonly IServiceMediator _serviceMediator = ServiceMediatorFactory.CreateMediator();

        public async Task<ServiceResponse<AccountServiceResponse>> GetAccountByIdAsync(Guid id)
        {
            var serviceRequest = new GetAccountByIdServiceRequest
            {
                Id = id
            };

            return await _serviceMediator
                .Handle<GetAccountByIdServiceRequest, AccountServiceResponse>(serviceRequest);
        }

        public async Task<ServiceResponse<AccountServiceResponse>> GetAccountByUsernameAsync(string username)
        {
            var serviceRequest = new GetAccountByUsernameServiceRequest
            {
                Username = username
            };

            return await _serviceMediator
                .Handle<GetAccountByUsernameServiceRequest, AccountServiceResponse>(serviceRequest);
        }

        public async Task<ServiceResponse> UpdateAccountAddressAsync(UpdateAccountAddressServiceRequest serviceRequest)
        {
            return await _serviceMediator
                .Handle(serviceRequest);
        }

        public async Task<ServiceResponse> UpdateAccountHeaderAsync(UpdateAccountHeaderServiceRequest serviceRequest)
        {
            return await _serviceMediator
                .Handle(serviceRequest);
        }
    }
}
