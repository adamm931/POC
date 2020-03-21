using POC.Accounts.Contracts;
using POC.Accounts.Data;
using POC.Common.Connection;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using System.Data.Entity;

namespace POC.Accounts.Service.DI
{
    public class AccountServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterMapping(GetType().Assembly);
            container.Register<IAccountContext, AccountContext>();
            container.RegisterInstance(ConnectionStringFactory.GetSqlConnectionString("Accounts"));
            container.Register<IDatabaseInitializer<AccountContext>, AccountContextSeeder>();
        }
    }
}