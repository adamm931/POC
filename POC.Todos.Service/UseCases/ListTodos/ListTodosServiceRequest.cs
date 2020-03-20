using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.ListTodos
{
    public class ListTodosServiceRequest : IServiceRequest<ListTodosServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : TodoServiceHandler<ListTodosServiceRequest, ListTodosServiceResponse>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task<ListTodosServiceResponse> Handle(ListTodosServiceRequest request)
            {
                var userTodos = await Context.UserTodos
                    .Include(item => item.TodoItems)
                    .FirstOrDefaultAsync(userItems => userItems.Username == request.Username);

                var items = Mapper.Map<List<ListTodosServiceResponse.Item>>(userTodos.TodoItems);

                return new ListTodosServiceResponse
                {
                    Items = items
                };
            }
        }
    }
}