using POC.Channel;
using POC.Configuration.DI;
using POC.Configuration.Mapping;

namespace POC.Web.DI
{
    public class PocWebPortalContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterMapping(GetType().Assembly);

            container.RegisterIdentityService();
            container.RegisterTodoService();
            container.RegisterAccountService();
        }
    }
}