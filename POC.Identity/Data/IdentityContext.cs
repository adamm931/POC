using POC.Common.Connection;
using POC.Common.Data;
using POC.Identity.Contracts;
using POC.Identity.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Identity.Data
{
    public class IdentityContext : BaseDbContext<IdentityContext>, IIdentityContext
    {
        public DbSet<CredentialRule> CredentialRules { get; set; }

        public DbSet<UserLogin> Logins { get; set; }

        public IdentityContext(
            IConnectionString connectionString,
            IDatabaseInitializer<IdentityContext> databaseInitializer)
            : base(connectionString, databaseInitializer)
        {
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await Logins.AnyAsync(login => login.Username.Value == username);
        }
    }
}
