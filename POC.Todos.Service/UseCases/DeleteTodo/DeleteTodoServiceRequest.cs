using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.DeleteTodo
{
    public class DeleteTodoServiceRequest : IServiceRequest
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public class Handler : TodoServiceHandler<DeleteTodoServiceRequest>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task Handle(DeleteTodoServiceRequest request)
            {
                var userTodos = await Context.UserTodos
                    .Include(item => item.TodoItems)
                    .FirstOrDefaultAsync(userItems => userItems.Username == request.Username);

                var todoToRemove = userTodos.DeleteTodo(request.Id);

                Context.Todos.Remove(todoToRemove);

                await Context.Save();
            }
        }
    }
}