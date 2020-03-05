using POC.Web.Models;

namespace POC.Web.AuthenticationService
{
    public interface IAuthenticationService
    {
        User GetUser();

        void LoginUser(User user);

        void LogoutUser();
    }
}