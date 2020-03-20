using POC.Identity.Web.Authentication.Contracts;
using POC.Identity.Web.Authentication.Extensions;
using POC.Identity.Web.Authentication.Principal;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Web.Common;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class PrincipalAuthenticationService : IAuthenticationService
    {
        private readonly IHttpContext _httpContext;
        private readonly IPrincipalProvider _principalProvider;
        private readonly IUserSession _userSession;

        public PrincipalAuthenticationService(
            IHttpContext httpContext,
            IPrincipalProvider principalProvider,
            IUserSession userSession)
        {
            _httpContext = httpContext;
            _principalProvider = principalProvider;
            _userSession = userSession;
        }

        public bool IsAuthenticated => _httpContext.Context.IsPrincipalAuthenticated();

        public IUser GetUser() => new PrincipalBasedUser(_httpContext.Context.User);

        public void LoginUser(IUser user)
        {
            var principal = new PrincipalUser(user.Username);

            _principalProvider.SetPrincipal(principal);
        }

        public void LogoutUser()
        {
            _principalProvider.ClearPrincipal();

            _httpContext.Context.Session.Abandon();

            _userSession.CloseSession();
        }
    }
}