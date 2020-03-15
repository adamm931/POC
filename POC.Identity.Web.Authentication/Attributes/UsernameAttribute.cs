using POC.Identity.Common;
using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Authentication.Attributes
{
    public class UsernameAttribute : RegularExpressionAttribute
    {
        public UsernameAttribute() : base(IdentityDefaults.RegularExpressions.Username)
        {
            ErrorMessage = "Username doesn't meet requirments";
        }
    }
}
