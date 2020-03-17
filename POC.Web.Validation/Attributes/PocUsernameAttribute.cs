using POC.Identity.Common;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Validation.Attributes
{
    public class PocUsernameAttribute : RegularExpressionAttribute
    {
        public PocUsernameAttribute() : base(IdentityDefaults.RegularExpressions.Username)
        {
            ErrorMessage = ValidationErrors.Username;
        }
    }
}
