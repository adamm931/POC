using FluentValidation;
using POC.Identity.Contracts;

namespace POC.Identity.Service.Common
{
    public class ExistingUsernameValidator : AbstractValidator<string>
    {
        public ExistingUsernameValidator(
            ICredentialRequirmentValidator credentialRequirmentValidator,
            IIdentityContext identityContext)
        {
            RuleFor(model => model)
                .MustAsync(async (model, token) => await identityContext.UsernameExists(model))
                .WithMessage((model, value) => $"Username {value} doesn't exists");
        }
    }
}
