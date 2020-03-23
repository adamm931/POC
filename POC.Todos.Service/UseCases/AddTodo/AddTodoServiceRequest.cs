using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using POC.Todos.Service.UseCases.Validation;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.AddTodo
{
    public class AddTodoServiceRequest : IServiceRequest<AddTodoServiceResponse>
    {
        public string Title { get; set; }

        public string Username { get; set; }

        public class Handler : TodoServiceHandler<AddTodoServiceRequest, AddTodoServiceResponse>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task<AddTodoServiceResponse> Handle(AddTodoServiceRequest request)
            {
                var userTodos = await Context.UserTodos
                    .Include(item => item.TodoItems)
                    .FirstOrDefaultAsync(userItems => userItems.Username == request.Username);

                var todo = userTodos.AddTodo(request.Title);

                await Context.Save();

                return Mapper.Map<AddTodoServiceResponse>(todo);
            }
        }

        public class Validator : AbstractValidator<AddTodoServiceRequest>
        {
            public Validator(ITodoContext context)
            {
                RuleFor(model => model.Title).NotEmpty();

                RuleFor(model => model.Username).ExistingUser(context);
            }
        }
    }
}