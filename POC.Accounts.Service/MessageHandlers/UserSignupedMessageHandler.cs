using POC.Accounts.Contracts;
using POC.Accounts.Domain;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using System.Threading.Tasks;

namespace POC.Accounts.Service.MessageHandlers
{
    public class UserSignupedMessageHandler : IMessageHandler<UserSignuped>
    {
        private readonly IAccountContext _context;

        public UserSignupedMessageHandler(IAccountContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(UserSignuped message)
        {
            var accountLogin = AccountLogin.CreateAndInitializeAccount(message.Username);

            _context.AccountLogins.Add(accountLogin);

            await _context.Save();
        }
    }
}