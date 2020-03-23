using POC.Identity.Service.Contracts;
using POC.Identity.Service.UseCases.Login;
using POC.Web.Common.Validation.Extensions;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace POC.Web.Validation.Attributes
{
    public class PocCheckCredentialsAttribute : ValidationAttribute
    {
        public string PasswordField { get; set; }

        public PocCheckCredentialsAttribute(string passwordField)
        {
            PasswordField = passwordField;

            ErrorMessage = ValidationErrors.InvalidCredentials;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var passwordResolution = validationContext.GetProperty<string>(PasswordField);

            if (!passwordResolution.IsValid)
            {
                return new ValidationResult(passwordResolution.ErrorMessage);
            }

            var username = value as string;
            var password = passwordResolution.Value;

            var identityService = DependencyResolver.Current.GetService<IIdentityService>();

            var response = identityService.LoginAsync(new UserLoginServiceRequest
            {
                Username = username,
                Password = password
            })
                .Result
                .EnsureSuccessfull();

            return response.IsAuthenticated ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
