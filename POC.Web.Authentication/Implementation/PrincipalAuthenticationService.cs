using POC.Web.Authentication.Contracts;
using POC.Web.Authentication.Extensions;
using POC.Web.Authentication.Principal;
using POC.Web.AuthenticationService.Contracts;
using System.Web;

namespace POC.Web.Authentication.Implementation
{
    internal class PrincipalAuthenticationService : IAuthenticationService
    {
        private readonly HttpContextBase _httpContext;
        private readonly IPrincipalProvider _principalProvider;

        public PrincipalAuthenticationService(
            HttpContextBase httpContext,
            IPrincipalProvider principalProvider)
        {
            _httpContext = httpContext;
            _principalProvider = principalProvider;
        }

        public bool IsAuthenticated => _httpContext.IsPrincipalAuthenticated();

        public IUser GetUser() => new PrincipalBasedUser(_httpContext.User);

        public void LoginUser(IUser user)
        {
            var principal = new PrincipalUser(user.Username);

            _principalProvider.SetPrincipal(principal);
        }

        public void LogoutUser() => _principalProvider.ClearPrincipal();
    }
}