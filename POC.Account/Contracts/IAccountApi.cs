using POC.Accounts.Model;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Contracts
{
    public interface IAccountApi
    {
        Task UpdateAccountHeaderAsync(AccountHeaderRequest request);

        Task UpdateAccountAddressAsync(AccountAddressRequest request);

        Task<AccountResponse> GetAccountAsync(Guid id);

        Task<AccountResponse> GetAccountByUsernameAsync(string username);

        Task<AccountLoginResponse> AddAccountLoginAsync(AccountLoginRequest request);

        Task<UpdateAccountLoginResponse> UpdateAccountLoginAsync(UpdateAccountLoginRequest request);
    }
}
