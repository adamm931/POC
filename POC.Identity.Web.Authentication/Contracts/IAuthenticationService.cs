using POC.Identity.Web.Authentication.Contracts;

namespace POC.Identity.Web.AuthenticationService.Contracts
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        IUser GetUser();

        void LoginUser(IUser user);

        void LogoutUser();
    }
}