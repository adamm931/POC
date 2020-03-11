using POC.Accounts.Contracts;
using POC.Accounts.Data;
using POC.Accounts.Domain;
using POC.Accounts.MappingProfiles;
using POC.Accounts.Model;
using POC.Common.Mapper;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Internal
{
    internal class AccountApi : IAccountApi
    {
        private readonly Mapping Mapping = Mapping.Create(new AccountMappingProfile());

        private readonly AccountContext Context = new AccountContext();

        public async Task<AccountLoginResponse> AddAccountLoginAsync(AccountLoginRequest request)
        {
            using (Context)
            {
                var accountLogin = AccountLogin.CreateAndInitializeAccount(request.Username);

                Context.AccountLogins.Add(accountLogin);

                await Context.SaveChangesAsync();

                return Mapping.Map<AccountLoginResponse>(accountLogin);
            }
        }

        public async Task<AccountResponse> GetAccountAsync(Guid id)
        {
            using (Context)
            {
                var account = await GetAccount(id);

                return Mapping.Map<AccountResponse>(account);
            }
        }

        public async Task<AccountResponse> GetAccountByUsernameAsync(string username)
        {
            using (Context)
            {
                var account = await GetAccount(username);

                return Mapping.Map<AccountResponse>(account);
            }
        }

        public async Task UpdateAccountAddressAsync(AccountAddressRequest request)
        {
            using (Context)
            {
                var account = await GetAccount(request.AccountId);

                account.UpdatetAddress(
                    request.Street,
                    request.City,
                    request.ZipCode,
                    request.Region,
                    request.Phone,
                    request.Email);

                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAccountHeaderAsync(AccountHeaderRequest request)
        {
            using (Context)
            {
                var account = await GetAccount(request.AccountId);

                account.UpdateHeader(
                    request.FirstName,
                    request.MiddleName,
                    request.LastName,
                    request.BirthDay,
                    Gender.Parse(request.Gender));

                await Context.SaveChangesAsync();
            }
        }

        public async Task<UpdateAccountLoginResponse> UpdateAccountLoginAsync(UpdateAccountLoginRequest request)
        {
            using (Context)
            {
                await CheckUsername(request.Username);

                var account = await GetAccount(request.AccountId);

                account.UpdateLogin(request.Username);

                await Context.SaveChangesAsync();

                return Mapping.Map<UpdateAccountLoginResponse>(account.Login);
            }
        }

        private async Task<Account> GetAccount(Guid id)
        {
            return await Context.Accounts
                .Include(model => model.Address)
                .Include(model => model.Login)
                .SingleAsync(model => model.Id == id);
        }

        private async Task<Account> GetAccount(string username)
        {
            return await Context.Accounts
                .Include(model => model.Address)
                .Include(model => model.Login)
                .SingleAsync(model => model.Login.Username == username);
        }

        private async Task CheckUsername(string username)
        {
            var exists = await Context.AccountLogins.AnyAsync(login => login.Username == username);

            if (exists)
            {
                throw new InvalidOperationException($"Username: {username} is not available");
            }
        }
    }
}
