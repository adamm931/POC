using POC.Identity.Web.Authentication.Models;

namespace POC.Identity.Web.Authentication.Service
{
    public interface IUserSession
    {
        void EnstablishSession(UserSessionModel user);

        void CloseSession();
    }
}
