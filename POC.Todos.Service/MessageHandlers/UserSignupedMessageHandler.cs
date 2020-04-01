using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using POC.Todos.Contracts;
using POC.Todos.Domain;
using System.Threading.Tasks;

namespace POC.Todos.Service.MessageHandlers
{
    public class UserSignupedMessageHandler : IMessageHandler<UserSignuped>
    {
        private readonly ITodoContext _context;

        public UserSignupedMessageHandler(ITodoContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(UserSignuped message)
        {
            _context.UserTodos.Add(new UserTodoItems(message.Username));

            await _context.Save();
        }
    }
}