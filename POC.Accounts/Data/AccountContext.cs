using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.Common.Connection;
using POC.Common.Data;
using System.Data.Entity;

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
    }
}
