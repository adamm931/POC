using FluentValidation;
using POC.Accounts.Contracts;
using System;

namespace POC.Accounts.Service.UseCases.Validation
{
    public class ExistingAccountByIdValidator : AbstractValidator<Guid>
    {
        public ExistingAccountByIdValidator(IAccountContext context)
        {
            // TODO: localize fluent validator exceptions
            RuleFor(model => model)
                .MustAsync(async (model, token) => await context.AccountByIdExists(model))
                .WithMessage((model, value) => $"Account with id: {value} is not found");
        }
    }
}