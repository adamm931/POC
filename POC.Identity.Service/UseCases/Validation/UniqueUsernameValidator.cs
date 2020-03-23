using FluentValidation;
using POC.Identity.Contracts;

namespace POC.Identity.Service.UseCases.Validation
{
    public class UniqueUsernameValidator : AbstractValidator<string>
    {
        public UniqueUsernameValidator(
            ICredentialRequirmentValidator credentialValidator,
            IIdentityContext identityContext)
        {
            RuleFor(model => model)
                .MustAsync(async (model, token) => !await identityContext.UsernameExists(model))
                .WithMessage((model, value) => $"Username: {value} is not available");
        }
    }
}