using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.Common.Connection;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Data
{
    public class AccountContext : DbContext, IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountLogin> AccountLogins { get; set; }

        public AccountContext(
            IConnectionString connectionString,
            IDatabaseInitializer<AccountContext> databaseInitializer)
            : base(connectionString.Value)
        {
            Database.SetInitializer(databaseInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        public async Task Save()
        {
            await base.SaveChangesAsync();
        }
    }
}
