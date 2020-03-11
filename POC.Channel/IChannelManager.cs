using POC.Accounts.Service.Contracts;
using POC.Identity.Service.Contracts;
using POC.Service.Contracts;

namespace POC.Channel
{
    public interface IChannelManager
    {
        ITodoService GetTodoService();

        IIdentityService GetIdentityService();

        IAccountService GetAccountService();
    }
}
