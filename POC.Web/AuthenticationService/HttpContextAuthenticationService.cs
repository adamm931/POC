using POC.Web.Models;
using System.Web;

namespace POC.Web.AuthenticationService
{
    public class HttpContextAuthenticationService : IAuthenticationService
    {
        private HttpContextBase _httpContext;

        public HttpContextAuthenticationService(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public User GetUser()
        {
            return _httpContext.Session["web_user"] as User;
        }

        public void LoginUser(User user)
        {
            _httpContext.Session["web_user"] = user;
        }

        public void LogoutUser()
        {
            _httpContext.Session["web_user"] = null;
        }
    }
}