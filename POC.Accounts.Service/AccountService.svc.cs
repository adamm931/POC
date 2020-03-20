using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Accounts.Service.UseCases.GetAccountById;
using POC.Accounts.Service.UseCases.GetAccountByUsername;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.UpdateAccountAddress;
using POC.Accounts.Service.UseCases.UpdateAccountHeader;
using POC.Common.Service;
using POC.Configuration.DI;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service
{
    public class AccountService : IAccountService
    {
        private readonly IServiceMediator ServiceMediator =
            new ServiceMediator(Container<AccountService>.Instance);

        public async Task<ServiceResponse<AddAccountLoginServiceResponse>> AddAccountLoginAsync(
            AddAccountLoginServiceRequest serviceRequest)
        {
            return await ServiceMediator
                .Handle<AddAccountLoginServiceRequest, AddAccountLoginServiceResponse>(serviceRequest);
        }

        public async Task<ServiceResponse<AccountServiceResponse>> GetAccountAsync(Guid id)
        {
            var serviceRequest = new GetAccountByIdServiceRequest
            {
                Id = id
            };

            return await ServiceMediator
                .Handle<GetAccountByIdServiceRequest, AccountServiceResponse>(serviceRequest);
        }

        public async Task<ServiceResponse<AccountServiceResponse>> GetAccountByUsername(string username)
        {
            var serviceRequest = new GetAccountByUsernameServiceRequest
            {
                Username = username
            };

            return await ServiceMediator
                .Handle<GetAccountByUsernameServiceRequest, AccountServiceResponse>(serviceRequest);
        }

        public async Task<ServiceResponse> UpdateAccountAddressAsync(UpdateAccountAddressServiceRequest serviceRequest)
        {
            return await ServiceMediator
                .Handle(serviceRequest);
        }

        public async Task<ServiceResponse> UpdateAccountHeaderAsync(UpdateAccountHeaderServiceRequest serviceRequest)
        {
            return await ServiceMediator
                .Handle(serviceRequest);
        }

        public async Task<ServiceResponse<UpdateAccountLoginServiceResponse>> UpdateAccountLoginAsync(
            UpdateAccountLoginServiceRequest serviceRequest)
        {
            return await ServiceMediator
                .Handle<UpdateAccountLoginServiceRequest, UpdateAccountLoginServiceResponse>(serviceRequest);
        }
    }
}
