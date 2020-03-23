using FluentValidation;
using POC.Todos.Contracts;
using System;
using System.Data.Entity;

namespace POC.Todos.Service.UseCases.Validation
{
    public class ExistingTodoValidator : AbstractValidator<Guid>
    {
        public ExistingTodoValidator(ITodoContext context)
        {
            RuleFor(model => model)
                .MustAsync(async (model, token) => await context.Todos.AnyAsync(todo => todo.Id == model))
                .WithMessage(model => $"Todo with id: {model} is not present");
        }
    }
}