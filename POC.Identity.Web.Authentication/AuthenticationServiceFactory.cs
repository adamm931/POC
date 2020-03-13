using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Implementation;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.AuthenticationService;
using POC.Identity.Web.AuthenticationService.Contracts;
using System.Web;

namespace POC.Identity.Web.Authentication
{
    public class AuthenticationServiceFactory
    {
        public static IAuthenticationService GetAutheticationService(HttpContextBase httpContext)
            => new PrincipalAuthenticationService(
                httpContext,
                GetPrincipalProvider(httpContext),
                GetUserSession(httpContext));

        public static IUserProvider GetUserProvider(HttpContextBase httpContext)
           => new CookieUserProvider(httpContext);

        public static IPrincipalProvider GetPrincipalProvider(HttpContextBase httpContext)
            => new SessionPrincipalProvider(httpContext);

        public static IUserSession GetUserSession(HttpContextBase httpContext)
            => new CookieUserSession(httpContext);

        public static IRedirectUrlProvider GetRedirectUrlProvider()
            => new RedirectUrlProvider();
    }
}