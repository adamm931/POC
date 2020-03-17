using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Validation.Attributes
{
    public class PocRequiredAttribute : RequiredAttribute
    {
        public PocRequiredAttribute(string name = null)
        {
            ErrorMessage = string.IsNullOrEmpty(name)
                ? ValidationErrors.EmptyFieldDefault
                : string.Format(ValidationErrors.EmptyField, name);
        }
    }
}
