using System.Security.Principal;

namespace POC.Web.Authentication.Principal
{
    internal class PrincipalUser : IPrincipal
    {
        public PrincipalUser(string name)
        {
            Identity = new UserIdentity(name);
        }

        public IIdentity Identity { get; }

        public bool IsInRole(string role) => true;
    }
}