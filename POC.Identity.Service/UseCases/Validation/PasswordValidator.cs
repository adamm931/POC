﻿using FluentValidation;
using POC.Identity.Contracts;
using POC.Identity.Domain.Enums;
using System;

namespace POC.Identity.Service.UseCases.Validation
{
    public class PasswordRequirmentValidator : AbstractValidator<string>
    {
        private readonly ICredentialRequirmentValidator _credentialValidator;

        public PasswordRequirmentValidator(ICredentialRequirmentValidator credentialValidator)
        {
            _credentialValidator = credentialValidator;

            RuleFor(model => model).NotEmpty();

            var reason = "Password doesn't meet requirments";

            RuleFor(model => model)
                .Must(model => ValidatePassword(model, out reason))
                .WithMessage(reason);
        }

        private bool ValidatePassword(string password, out string reason)
        {
            // TODO: see how to set dynamic message to method WithMessage(...)
            reason = string.Empty;

            var result = _credentialValidator
                .ValidateAsync(CredentialType.Password, password)
                .Result;

            if (result.IsValid)
            {
                return true;
            }

            reason = string.Join(Environment.NewLine, result.ValidationErrors);

            return false;
        }
    }
}