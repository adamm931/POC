using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Domain;
using POC.Todos.Service.UseCases.Base;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.AddUser
{
    public class AddUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public class Handler : TodoServiceHandler<AddUserServiceRequest>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task Handle(AddUserServiceRequest request)
            {
                Context.UserTodos.Add(new UserTodoItems(request.Username));

                await Context.Save();
            }
        }
    }
}