using POC.Identity.Web.Authentication.Common;
using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Extensions;
using POC.Web.Common;
using System.Security.Principal;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class SessionPrincipalProvider : IPrincipalProvider
    {
        private readonly IHttpContext _httpContext;

        public SessionPrincipalProvider(IHttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public IPrincipal GetPrincipal()
        {
            return _httpContext.Context.Session[Constants.Session.Principal] as IPrincipal;
        }

        public void SetPrincipal(IPrincipal principal)
        {
            SetToContext(principal);

            _httpContext.Context.Session[Constants.Session.Principal] = principal;
        }

        public void MaintainPrincipal()
        {
            var currentPrincipal = GetPrincipal();

            SetToContext(currentPrincipal);
        }

        public void ClearPrincipal()
        {
            _httpContext.Context.Session[Constants.Session.Principal] = null;
        }

        private void SetToContext(IPrincipal principal)
        {
            if (!_httpContext.Context.IsPrincipalAuthenticated())
            {
                _httpContext.Context.User = principal;
            }
        }
    }
}
