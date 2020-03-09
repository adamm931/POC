using POC.Web.Authentication.Contracts;

namespace POC.Web.AuthenticationService.Contracts
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        IUser GetUser();

        void LoginUser(IUser user);

        void LogoutUser();
    }
}