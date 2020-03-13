using System.Web.Mvc;

namespace POC.Identity.Web.Authentication.Filter
{
    internal class PrincipalPersistFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            PersistPrincipal(filterContext);

            base.OnActionExecuting(filterContext);
        }

        private void PersistPrincipal(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }

            var principalProvider = AuthenticationServiceFactory.GetPrincipalProvider(filterContext.HttpContext);

            principalProvider.MaintainPrincipal();
        }
    }
}