using POC.Accounts.Factory;
using POC.Configuration.DI;
using POC.Configuration.Mapping;

namespace POC.Accounts.Service.Configuration
{
    public class AccountServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterInstance(AccountApiFactory.GetAccountApi());
            container.RegisterMapping(GetType().Assembly);
        }
    }
}