using FluentValidation;
using POC.Accounts.Contracts;

namespace POC.Accounts.Service.UseCases.Validation
{
    public class ExistingAccountByUsernameValidator : AbstractValidator<string>
    {
        public ExistingAccountByUsernameValidator(IAccountContext context)
        {
            RuleFor(model => model)
                .MustAsync(async (model, token) => await context.AccountByUsernameExists(model))
                .WithMessage((model, value) => $"Account with username: {value} is not found");
        }
    }
}