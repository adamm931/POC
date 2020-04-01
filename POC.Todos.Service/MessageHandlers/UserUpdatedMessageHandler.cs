using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using POC.Todos.Contracts;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Service.MessageHandlers
{
    public class UserUpdatedMessageHandler : IMessageHandler<UserUpdated>
    {
        private readonly ITodoContext _context;

        public UserUpdatedMessageHandler(ITodoContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(UserUpdated message)
        {
            var userTodos = await _context.UserTodos
                .SingleAsync(user => user.Username == message.OldUsername);

            userTodos.UpdateUser(message.NewUsername);

            await _context.Save();
        }
    }
}