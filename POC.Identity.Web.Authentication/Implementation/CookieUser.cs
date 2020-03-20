using POC.Identity.Web.Authentication.Common;
using POC.Identity.Web.Authentication.Contracts;
using System;
using System.Web;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class CookieUser : IUser
    {
        public CookieUser(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Username = request.Cookies[Constants.Cookies.User]?.Value;
        }

        public string Username { get; }
    }
}
