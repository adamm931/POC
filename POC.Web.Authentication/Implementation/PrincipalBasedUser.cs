using POC.Web.Authentication.Contracts;
using System.Security.Principal;

namespace POC.Web.Authentication.Implementation
{
    internal class PrincipalBasedUser : IUser
    {
        public PrincipalBasedUser(IPrincipal principal)
        {
            Username = principal.Identity.Name;
        }

        public string Username { get; }
    }
}
