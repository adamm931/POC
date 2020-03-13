using System.Security.Principal;

namespace POC.Identity.Web.Authentication.Contracts
{
    public interface IPrincipalProvider
    {
        IPrincipal GetPrincipal();

        void SetPrincipal(IPrincipal principal);

        void ClearPrincipal();

        void MaintainPrincipal();
    }
}
