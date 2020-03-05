using System.Web;

namespace POC.Web.AuthenticationService
{
    public class AuthenticationServiceFactory
    {
        public static IAuthenticationService GetAutheticationService(HttpContextBase httpContext)
            => new HttpContextAuthenticationService(httpContext);

        public static IUserProvider GetUserProvider(HttpContextBase httpContext)
           => new QueryStringUserProvider(httpContext);
    }
}