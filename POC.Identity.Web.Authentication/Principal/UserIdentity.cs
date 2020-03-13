using System.Security.Principal;

namespace POC.Identity.Web.Authentication.Principal
{
    internal class UserIdentity : IIdentity
    {
        public UserIdentity(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string AuthenticationType => string.Empty;

        public bool IsAuthenticated => !string.IsNullOrEmpty(Name);
    }
}