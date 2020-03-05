using POC.Web.Models;
using System.Web;

namespace POC.Web.AuthenticationService
{
    public class QueryStringUserProvider : IUserProvider
    {
        private HttpContextBase _httpContext;

        public QueryStringUserProvider(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }
        public User GetUser()
        {
            var username = _httpContext.Request.QueryString["user"];

            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            return new User
            {
                Username = username
            };
        }
    }
}