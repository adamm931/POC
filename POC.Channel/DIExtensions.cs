using POC.Configuration.DI;

namespace POC.Channel
{
    public static class DIExtensions
    {
        public static void RegisterAccountService(this IContainer container)
        {
            container.RegisterInstance(ChannelManager.Instance.GetAccountService());
        }

        public static void RegisterIdentityService(this IContainer container)
        {
            container.RegisterInstance(ChannelManager.Instance.GetIdentityService());
        }

        public static void RegisterTodoService(this IContainer container)
        {
            container.RegisterInstance(ChannelManager.Instance.GetTodoService());
        }
    }
}
