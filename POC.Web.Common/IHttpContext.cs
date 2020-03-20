using System.Web;

namespace POC.Web.Common
{
    public interface IHttpContext
    {
        HttpContext Context { get; }
    }
}
