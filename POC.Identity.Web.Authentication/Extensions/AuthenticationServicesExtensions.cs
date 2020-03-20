using POC.Configuration.DI;
using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Implementation;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.AuthenticationService;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Web.Common;

namespace POC.Identity.Web.Authentication.Extensions
{
    public static class AuthenticationServicesExtensions
    {
        public static void RegisterAuthenticationServices(this IContainer container)
        {
            container.RegisterHttpContext();
            container.Register<IAuthenticationService, PrincipalAuthenticationService>();
            container.Register<IUserProvider, CookieUserProvider>();
            container.Register<IPrincipalProvider, SessionPrincipalProvider>();
            container.Register<IUserSession, CookieUserSession>();
            container.Register<IRedirectUrlProvider, RedirectUrlProvider>();
        }
    }
}
