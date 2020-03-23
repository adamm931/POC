using FluentValidation;
using POC.Todos.Contracts;

namespace POC.Todos.Service.UseCases.Validation
{
    public class ExistingUserValidator : AbstractValidator<string>
    {
        public ExistingUserValidator(ITodoContext context)
        {
            RuleFor(model => model)
                .MustAsync(async (model, token) => await context.UserExists(model))
                .WithMessage(model => $"User: {model} is not found");
        }
    }
}