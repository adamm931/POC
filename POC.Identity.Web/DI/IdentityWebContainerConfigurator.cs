using POC.Channel;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Identity.Web.Authentication.Extensions;

namespace POC.Identity.Web.DI
{
    public class IdentityWebContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterIdentityService();
            container.RegisterTodoService();
            container.RegisterAccountService();
            container.RegisterMapping(GetType().Assembly);
            container.RegisterAuthenticationServices();
        }
    }
}