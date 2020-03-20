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
        private readonly IMapping Mapper = Mapping.Create(new AccountMappingProfile());

        public async Task<AccountLoginResponse> AddAccountLoginAsync(AccountLoginRequest request)
        {
            using (var context = new AccountContext())
            {
                var accountLogin = AccountLogin.CreateAndInitializeAccount(request.Username);

                context.AccountLogins.Add(accountLogin);

                await context.SaveChangesAsync();

                return Mapper.Map<AccountLoginResponse>(accountLogin);
            }
        }

        public async Task<AccountResponse> GetAccountAsync(Guid id)
        {
            using (var context = new AccountContext())
            {
                var account = await GetAccount(id, context);

                return Mapper.Map<AccountResponse>(account);
            }
        }

        public async Task<AccountResponse> GetAccountByUsernameAsync(string username)
        {
            using (var context = new AccountContext())
            {
                var account = await GetAccount(username, context);

                return Mapper.Map<AccountResponse>(account);
            }
        }

        public async Task UpdateAccountAddressAsync(AccountAddressRequest request)
        {
            using (var context = new AccountContext())
            {
                try
                {
                    var account = await GetAccount(request.AccountUsername, context);

                    account.UpdatetAddress(
                        request.Street,
                        request.City,
                        request.ZipCode,
                        request.Region,
                        request.Phone,
                        request.Email);

                    await context.SaveChangesAsync();
                }

                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        public async Task UpdateAccountHeaderAsync(AccountHeaderRequest request)
        {
            using (var context = new AccountContext())
            {
                var account = await GetAccount(request.AccountUsername, context);

                account.UpdateHeader(
                    request.FirstName,
                    request.MiddleName,
                    request.LastName,
                    request.BirthDay,
                    request.Gender);

                await context.SaveChangesAsync();
            }
        }

        public async Task<UpdateAccountLoginResponse> UpdateAccountLoginAsync(UpdateAccountLoginRequest request)
        {
            using (var context = new AccountContext())
            {
                await CheckUsername(request.AccountNewUsername, context);

                var account = await GetAccount(request.AccountUsername, context);

                account.UpdateLogin(request.AccountNewUsername);

                await context.SaveChangesAsync();

                return Mapper.Map<UpdateAccountLoginResponse>(account.Login);
            }
        }

        private async Task<Account> GetAccount(string username, AccountContext context)
        {
            return await context.Accounts
                .Include(model => model.Address)
                .Include(model => model.Login)
                .SingleAsync(model => model.Login.Username == username);
        }

        private async Task<Account> GetAccount(Guid id, AccountContext context)
        {
            return await context.Accounts
                .Include(model => model.Address)
                .Include(model => model.Login)
                .SingleAsync(model => model.Id == id);
        }

        private async Task CheckUsername(string username, AccountContext context)
        {
            var exists = await context.AccountLogins.AnyAsync(login => login.Username == username);

            if (exists)
            {
                throw new InvalidOperationException($"Username: {username} is not available");
            }
        }
    }
}
