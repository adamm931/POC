using POC.Accounts.Service.Contracts;
using POC.Identity.Service.Contracts;
using POC.Logging.Service.Contracts;
using POC.Todos.Service.Contracts;

namespace POC.Channel
{
    public interface IChannelManager
    {
        ITodoService GetTodoService();

        IIdentityService GetIdentityService();

        IAccountService GetAccountService();

        ILoggingService GetLoggingService();
    }
}
