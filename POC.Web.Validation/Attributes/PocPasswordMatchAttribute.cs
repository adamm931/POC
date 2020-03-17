using POC.Web.Common.Validation.Extensions;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Validation.Attributes
{
    public class PocPasswordMatchAttribute : ValidationAttribute
    {
        public string ConfirmPasswordField { get; set; }

        public PocPasswordMatchAttribute(string confirmPasswordField)
        {
            ErrorMessage = ValidationErrors.PasswordNotMatch;
            ConfirmPasswordField = confirmPasswordField;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var confirmPasswordResolution = validationContext.GetProperty<string>(ConfirmPasswordField);

            if (!confirmPasswordResolution.IsValid)
            {
                return new ValidationResult(confirmPasswordResolution.ErrorMessage);
            }

            return confirmPasswordResolution.Value == (string)value ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
