using POC.Web.Authentication.Contracts;
using POC.Web.Authentication.Implementation;
using POC.Web.AuthenticationService;
using POC.Web.AuthenticationService.Contracts;
using System.Web;

namespace POC.Web.Authentication
{
    public class AuthenticationServiceFactory
    {
        public static IAuthenticationService GetAutheticationService(HttpContextBase httpContext)
            => new PrincipalAuthenticationService(httpContext, GetPrincipalProvider(httpContext));

        public static IUserProvider GetUserProvider(HttpContextBase httpContext)
           => new QueryStringUserProvider(httpContext);

        public static IPrincipalProvider GetPrincipalProvider(HttpContextBase httpContext)
            => new SessionPrincipalProvider(httpContext);
    }
}