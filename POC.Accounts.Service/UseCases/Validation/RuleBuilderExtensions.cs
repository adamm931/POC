using FluentValidation;
using POC.Accounts.Contracts;
using System;

namespace POC.Accounts.Service.UseCases.Validation
{
    public static class RuleBuilderExtensions
    {
        public static void ExistingAccountById<TRequest>(
            this IRuleBuilderInitial<TRequest, Guid> builder,
            IAccountContext context)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new ExistingAccountByIdValidator(context));
        }

        public static void ExistingAccountByUsername<TRequest>(
            this IRuleBuilderInitial<TRequest, string> builder,
            IAccountContext context)
        {
            builder
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .SetValidator(new ExistingAccountByUsernameValidator(context));
        }
    }
}