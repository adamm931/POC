using FluentValidation;
using POC.Identity.Contracts;
using POC.Identity.Domain.Enums;
using System;

namespace POC.Identity.Service.Common
{
    public class UsernameValidator : AbstractValidator<string>
    {
        public UsernameValidator(ICredentialRequirmentValidator credentialValidator)
        {
            var reason = "Username doesn't meet requirments";

            RuleFor(model => model)
                .Must(model => ValidateUsername(credentialValidator, model, out reason))
                .WithMessage(reason);
        }

        private bool ValidateUsername(ICredentialRequirmentValidator validator, string value, out string reason)
        {
            reason = string.Empty;

            var result = validator
                .ValidateAsync(CredentialType.Username, value)
                .Result;

            if (!result.IsValid)
            {
                reason = string.Join(Environment.NewLine, result.ValidationErrors);
                return false;
            }
            return true;
        }
    }
}