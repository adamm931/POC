using System.Web;

namespace POC.Web.Common
{
    internal class CurrentHttpContext : IHttpContext
    {
        public HttpContext Context => HttpContext.Current;
    }
}
