using POC.Identity.Common;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Validation.Attributes
{
    public class PocPasswordAttribute : RegularExpressionAttribute
    {
        public PocPasswordAttribute() : base(IdentityDefaults.RegularExpressions.Password)
        {
            ErrorMessage = ValidationErrors.Password;
        }
    }
}
