using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.Common.Connection;
using POC.Common.Data;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Data
{
    public class AccountContext : BaseDbContext<AccountContext>, IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountLogin> AccountLogins { get; set; }

        public AccountContext(
            IConnectionString connectionString,
            IDatabaseInitializer<AccountContext> databaseInitializer)
            : base(connectionString, databaseInitializer)
        {
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Id == id);
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == username);
        }

        public async Task<bool> AccountByIdExists(Guid id)
        {
            return await Accounts.AnyAsync(account => account.Id == id);
        }

        public async Task<bool> AccountByUsernameExists(string username)
        {
            return await Accounts
                .Include(account => account.Login)
                .AnyAsync(account => account.Login.Username == username);
        }
    }
}
