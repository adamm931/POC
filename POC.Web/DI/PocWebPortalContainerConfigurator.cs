using POC.Channel;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Identity.Web.Authentication.Extensions;

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
            container.RegisterAuthenticationServices();
        }
    }
}