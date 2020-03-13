using POC.Common.Enviroment;
using POC.Identity.Web.Authentication.Common;
using POC.Identity.Web.Authentication.Models;
using POC.Identity.Web.Authentication.Service;
using System;
using System.Web;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class CookieUserSession : IUserSession
    {
        private readonly HttpContextBase _httpContext;

        public CookieUserSession(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public void CloseSession()
        {
            _httpContext.Response.Cookies[Constants.Cookies.User].Expires = DateTime.Now.AddDays(-1);
        }

        public void EnstablishSession(UserSessionModel user)
        {
            var userCookie = new HttpCookie(Constants.Cookies.User, user.Username)
            {
                Domain = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.UserCookieDomain),
            };

            _httpContext.Response.Cookies.Add(userCookie);
        }
    }
}