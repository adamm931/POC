using POC.Accounts.Domain;
using POC.Common.Domain;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Contracts
{
    public interface IAccountContext : IUnitOfWork
    {
        DbSet<Account> Accounts { get; }

        DbSet<AccountLogin> AccountLogins { get; }

        Task<Account> GetAccountById(Guid id);

        Task<bool> AccountByIdExists(Guid id);

        Task<Account> GetAccountByUsername(string username);

        Task<bool> AccountByUsernameExists(string username);
    }
}
