using POC.Identity.Web.Authentication.Common;
using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Extensions;
using System.Security.Principal;
using System.Web;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class SessionPrincipalProvider : IPrincipalProvider
    {
        private readonly HttpContextBase _httpContext;

        public SessionPrincipalProvider(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public IPrincipal GetPrincipal()
        {
            return _httpContext.Session[Constants.Session.Principal] as IPrincipal;
        }

        public void SetPrincipal(IPrincipal principal)
        {
            SetToContext(principal);

            _httpContext.Session[Constants.Session.Principal] = principal;
        }

        public void MaintainPrincipal()
        {
            var currentPrincipal = GetPrincipal();

            SetToContext(currentPrincipal);
        }

        public void ClearPrincipal()
        {
            _httpContext.Session[Constants.Session.Principal] = null;
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
