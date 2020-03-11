using POC.Accounts.Contracts;
using POC.Accounts.Factory;
using POC.Accounts.Model;
using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.MappingProfiles;
using POC.Accounts.Service.Model;
using POC.Common.Mapper;
using POC.Common.Service;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service
{
    public class AccountService : IAccountService
    {
        private readonly Mapping Mapping = Mapping.Create(new AccountMappingProfile());

        private readonly IAccountApi AccountApi = AccountApiFactory.GetAccountApi();

        public async Task<ServiceResponse<AccountLoginServiceResponse>> AddAccountLoginAsync(AccountLoginServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<AccountLoginRequest>(serviceRequest);

                var response = await AccountApi.AddAccountLoginAsync(request);

                return Mapping.Map<AccountLoginServiceResponse>(response);
            });
        }

        public async Task<ServiceResponse<AccountServiceResponse>> GetAccountAsync(Guid id)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var response = await AccountApi.GetAccountAsync(id);

                return Mapping.Map<AccountServiceResponse>(response);
            });
        }

        public async Task<ServiceResponse> UpdateAccountAddressAsync(AccountAddressServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<AccountAddressRequest>(serviceRequest);

                await AccountApi.UpdateAccountAddressAsync(request);
            });
        }

        public async Task<ServiceResponse> UpdateAccountHeaderAsync(AccountHeaderServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<AccountHeaderRequest>(serviceRequest);

                await AccountApi.UpdateAccountHeaderAsync(request);
            });
        }

        public async Task<ServiceResponse<UpdateAccountLoginServiceResponse>> UpdateAccountLoginAsync(UpdateAccountLoginServiceRequest serviceRequest)
        {
            return await ServiceTrigger.Handle(async () =>
            {
                var request = Mapping.Map<UpdateAccountLoginRequest>(serviceRequest);

                var response = await AccountApi.UpdateAccountLoginAsync(request);

                return Mapping.Map<UpdateAccountLoginServiceResponse>(response);
            });
        }
    }
}
