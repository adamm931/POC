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
            RuleFor(model => model).SetValidator(new UsernameValidator(credentialValidator));

            RuleFor(model => model)
                .Must(model => !identityContext.UsernameExists(model).Result)
                .WithMessage(value => $"Username: {value} is not available");
        }
    }
}