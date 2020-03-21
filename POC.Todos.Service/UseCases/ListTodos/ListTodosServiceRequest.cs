using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.ListTodos
{
    public class ListTodosServiceRequest : IServiceRequest<IEnumerable<ListTodosItemServiceResponse>>
    {
        public string Username { get; set; }

        public class Handler : TodoServiceHandler<ListTodosServiceRequest, IEnumerable<ListTodosItemServiceResponse>>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task<IEnumerable<ListTodosItemServiceResponse>> Handle(ListTodosServiceRequest request)
            {
                var userTodos = await Context.UserTodos
                    .Include(item => item.TodoItems)
                    .FirstOrDefaultAsync(userItems => userItems.Username == request.Username);

                return Mapper.Map<IEnumerable<ListTodosItemServiceResponse>>(userTodos.TodoItems);
            }
        }
    }
}