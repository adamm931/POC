using POC.Identity.Web.Authentication.Contracts;

namespace POC.Identity.Web.AuthenticationService.Contracts
{
    public interface IUserProvider
    {
        IUser GetUser();
    }
}
