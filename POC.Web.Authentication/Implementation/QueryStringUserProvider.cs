using POC.Web.Authentication.Contracts;
using POC.Web.Authentication.Implementation;
using POC.Web.AuthenticationService.Contracts;
using System.Web;

namespace POC.Web.AuthenticationService
{
    internal class QueryStringUserProvider : IUserProvider
    {
        private readonly HttpContextBase _httpContext;

        public QueryStringUserProvider(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public IUser GetUser()
        {
            return new QueryStringUser(_httpContext.Request);
        }
    }
}