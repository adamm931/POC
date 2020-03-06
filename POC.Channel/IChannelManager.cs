using POC.Identity.Service.Contracts;
using POC.Service.Contracts;

namespace POC.Channel
{
    public interface IChannelManager
    {
        ITodoService GetTodoService();

        IIdentityService GetIdentityService();

    }
}
