using POC.Configuration.DI;
using POC.Configuration.DI.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POC.Identity.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerProvider.ApplyConfigurationFromAssembly(typeof(MvcApplication));
            DependencyResolver.SetResolver(new PocDependancyResolver<MvcApplication>());
        }
    }
}
