using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Implementation;
using POC.Identity.Web.AuthenticationService.Contracts;
using System.Web;

namespace POC.Identity.Web.AuthenticationService
{
    internal class CookieUserProvider : IUserProvider
    {
        private readonly HttpContextBase _httpContext;

        public CookieUserProvider(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public IUser GetUser()
        {
            return new CookieUser(_httpContext.Request);
        }
    }
}