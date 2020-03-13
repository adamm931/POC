using POC.Identity.Web.Authentication.Filter;
using System.Web.Mvc;

namespace POC.Identity.Web.Authentication.Extensions
{
    public static class GlobalFilterExtensions
    {
        public static void AddAuthentication(this GlobalFilterCollection collection)
        {
            collection.Add(new AuthenticationFilterAttribute());
        }
    }
}
