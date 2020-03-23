using FluentValidation;
using POC.Todos.Contracts;
using System;

namespace POC.Todos.Service.UseCases.Validation
{
    public static class RuleBuilderExtensions
    {
        public static void ExistingUser<TRequest>(
            this IRuleBuilder<TRequest, string> ruleBuilder,
            ITodoContext context)
        {
            ruleBuilder
                .NotEmpty()
                .SetValidator(new ExistingUserValidator(context));
        }

        public static void ExistingTodo<TRequest>(
            this IRuleBuilder<TRequest, Guid> ruleBuilder,
            ITodoContext context)
        {
            ruleBuilder
                .NotEmpty()
                .SetValidator(new ExistingTodoValidator(context));
        }
    }
}