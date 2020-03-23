using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using POC.Todos.Service.UseCases.Validation;
using System;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.CompleteTodo
{
    public class CompleteTodoServiceRequest : IServiceRequest
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public class Handler : TodoServiceHandler<CompleteTodoServiceRequest>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task Handle(CompleteTodoServiceRequest request)
            {
                var userTodos = await Context.GetUserTodos(request.Username);

                userTodos.CompleteTodo(request.Id);

                await Context.Save();
            }
        }

        public class Validator : AbstractValidator<CompleteTodoServiceRequest>
        {
            public Validator(ITodoContext context)
            {
                RuleFor(model => model.Username).ExistingUser(context);

                RuleFor(model => model.Id).ExistingTodo(context);
            }
        }

    }
}