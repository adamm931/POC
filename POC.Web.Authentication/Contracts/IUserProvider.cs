using POC.Web.Authentication.Contracts;

namespace POC.Web.AuthenticationService.Contracts
{
    public interface IUserProvider
    {
        IUser GetUser();
    }
}
