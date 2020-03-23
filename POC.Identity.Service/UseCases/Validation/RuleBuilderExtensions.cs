using FluentValidation;
using POC.Identity.Contracts;

namespace POC.Identity.Service.UseCases.Validation
{
    public static class RuleBuilderExtensions
    {
        public static void UniqueUsername<TRequest>(
            this IRuleBuilderInitial<TRequest, string> builder,
            ICredentialRequirmentValidator validator,
            IIdentityContext context)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new UsernameValidator(validator))
                .SetValidator(new UniqueUsernameValidator(validator, context));
        }

        public static void Username<TRequest>(
            this IRuleBuilderInitial<TRequest, string> builder,
            ICredentialRequirmentValidator validator)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new UsernameValidator(validator));
        }

        public static void ExistingUsername<TRequest>(
            this IRuleBuilderInitial<TRequest, string> builder,
            ICredentialRequirmentValidator validator,
            IIdentityContext context)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new UsernameValidator(validator))
                .SetValidator(new ExistingUsernameValidator(validator, context));
        }

        public static void Password<TRequest>(
            this IRuleBuilderInitial<TRequest, string> builder,
            ICredentialRequirmentValidator validator)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new PasswordValidator(validator));
        }
    }
}
