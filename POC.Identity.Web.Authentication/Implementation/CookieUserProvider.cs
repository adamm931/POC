using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Implementation;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Web.Common;

namespace POC.Identity.Web.AuthenticationService
{
    internal class CookieUserProvider : IUserProvider
    {
        private readonly IHttpContext _httpContext;

        public CookieUserProvider(IHttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public IUser GetUser()
        {
            return new CookieUser(_httpContext.Context.Request);
        }
    }
}