using POC.Identity.Common;
using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Authentication.Attributes
{
    public class PasswordAttribute : RegularExpressionAttribute
    {
        public PasswordAttribute() : base(IdentityDefaults.RegularExpressions.Password)
        {
            ErrorMessage = "Password doesn't meet requirments";
        }
    }
}
