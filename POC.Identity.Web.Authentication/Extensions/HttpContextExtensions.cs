using System.Web;

namespace POC.Identity.Web.Authentication.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsPrincipalAuthenticated(this HttpContextBase httpContext)
        {
            return httpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
