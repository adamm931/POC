using POC.Web.Models;
using System.Web;

namespace POC.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUsername(this HttpSessionStateBase session)
        {
            var user = session["web_user"] as User;

            return user?.Username ?? string.Empty;
        }
    }
}