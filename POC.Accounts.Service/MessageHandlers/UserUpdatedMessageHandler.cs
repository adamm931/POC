using POC.Accounts.Contracts;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Service.MessageHandlers
{
    public class UserUpdatedMessageHandler : IMessageHandler<UserUpdated>
    {
        private readonly IAccountContext _context;

        public UserUpdatedMessageHandler(IAccountContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(UserUpdated message)
        {
            var account = await _context.Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == message.OldUsername);

            account.UpdateLogin(message.NewUsername);

            await _context.Save();
        }
    }
}