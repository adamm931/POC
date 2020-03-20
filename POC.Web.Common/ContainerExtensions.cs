using POC.Configuration.DI;

namespace POC.Web.Common
{
    public static class ContainerExtensions
    {
        public static void RegisterHttpContext(this IContainer container)
        {
            container.RegisterInstance<IHttpContext>(new CurrentHttpContext());
        }
    }
}
