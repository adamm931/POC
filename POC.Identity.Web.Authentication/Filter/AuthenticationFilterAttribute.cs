using POC.Common.Enviroment;
using POC.Identity.Web.Authentication.Contracts;
using System.Web.Mvc;

namespace POC.Identity.Web.Authentication.Filter
{
    internal class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        private readonly ActionFilterAttribute principalFilter;

        public AuthenticationFilterAttribute()
        {
            principalFilter = new PrincipalPersistFilterAttribute();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            principalFilter.OnActionExecuting(filterContext);

            Authenticate(filterContext);

            base.OnActionExecuting(filterContext);
        }

        private void Authenticate(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }

            var authenticationService = AuthenticationServiceFactory.GetAutheticationService(filterContext.HttpContext);

            if (authenticationService.IsAuthenticated)
            {
                return;
            }

            var userProvider = AuthenticationServiceFactory.GetUserProvider(filterContext.HttpContext);
            var user = userProvider.GetUser();

            if (user.IsResolved())
            {
                authenticationService.LoginUser(user);
                return;
            }

            var url = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.IdentityUrl);
            filterContext.Result = new RedirectResult(url);
        }
    }
}