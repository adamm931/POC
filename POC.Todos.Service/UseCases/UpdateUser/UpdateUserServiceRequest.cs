using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Service.UseCases.Base;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.UpdateUser
{
    public class UpdateUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string NewUsername { get; set; }

        public class Handler : TodoServiceHandler<UpdateUserServiceRequest>
        {
            public Handler(ITodoContext context, IMapping mapper) : base(context, mapper)
            {
            }

            public override async Task Handle(UpdateUserServiceRequest request)
            {
                var userItem = await Context.UserTodos
                    .SingleOrDefaultAsync(item => item.Username == request.Username);

                userItem.UpdateUser(request.NewUsername);

                await Context.Save();
            }
        }
    }
}