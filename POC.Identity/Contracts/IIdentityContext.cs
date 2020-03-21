using POC.Common.Domain;
using POC.Identity.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface IIdentityContext : IUnitOfWork
    {
        DbSet<UserLogin> Logins { get; }

        DbSet<CredentialRule> CredentialRules { get; }

        Task<bool> UsernameExists(string username);
    }
}
