using POC.Web.Models;

namespace POC.Web.AuthenticationService
{
    public interface IUserProvider
    {
        User GetUser();
    }
}
