using POC.Web.Authentication.Contracts;
using POC.Web.Authentication.Extensions;
using System.Security.Principal;
using System.Web;

namespace POC.Web.Authentication.Implementation
{
    public class SessionPrincipalProvider : IPrincipalProvider
    {
        private readonly HttpContextBase _httpContext;

        public SessionPrincipalProvider(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public IPrincipal GetPrincipal()
        {
            return _httpContext.Session["Principal"] as IPrincipal;
        }

        public void SetPrincipal(IPrincipal principal)
        {
            SetToContext(principal);

            _httpContext.Session["Principal"] = principal;
        }

        public void MaintainPrincipal()
        {
            var currentPrincipal = GetPrincipal();

            SetToContext(currentPrincipal);
        }

        public void ClearPrincipal()
        {
            _httpContext.Session["Principal"] = null;
        }

        private void SetToContext(IPrincipal principal)
        {
            if (!_httpContext.IsPrincipalAuthenticated())
            {
                _httpContext.User = principal;
            }
        }
    }
}
