using POC.Accounts.Domain;
using POC.Common.Domain;
using System.Data.Entity;

namespace POC.Accounts.Contracts
{
    public interface IAccountContext : IUnitOfWork
    {
        DbSet<Account> Accounts { get; }

        DbSet<AccountLogin> AccountLogins { get; }
    }
}
