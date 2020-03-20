using POC.Configuration.DI.Mvc;
using POC.Identity.Web.Authentication.Extensions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POC.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalFilters.Filters.AddAuthentication();

            DependencyResolver.SetResolver(new PocDependancyResolver<MvcApplication>());
        }
    }
}
