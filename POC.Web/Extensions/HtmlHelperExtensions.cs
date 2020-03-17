using System.Web.Mvc;

namespace POC.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string IsActive(this HtmlHelper html, string controller, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = routeData.Values["action"] as string;
            var routeController = routeData.Values["controller"] as string;

            var isActive = controller == routeController && action == routeAction;

            return isActive ? "active" : string.Empty;
        }
    }
}