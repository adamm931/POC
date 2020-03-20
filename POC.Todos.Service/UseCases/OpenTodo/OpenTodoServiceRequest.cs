using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.OpenTodo
{
    public class OpenTodoServiceRequest : IServiceRequest
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public class Handler : TodoServiceHandler<OpenTodoServiceRequest>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task Handle(OpenTodoServiceRequest request)
            {
                var userTodos = await Context.UserTodos
                    .Include(item => item.TodoItems)
                    .SingleAsync(data => data.Username == request.Username);

                userTodos.OpenTodo(request.Id);

                await Context.Save();
            }
        }
    }
}