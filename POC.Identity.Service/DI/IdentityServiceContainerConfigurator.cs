using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;

namespace POC.Identity.Service.DI
{
    public class IdentityServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterMapping(GetType().Assembly);
            container.RegisterInstance<IIdentityApi>(new IdentityApi());
        }
    }
}