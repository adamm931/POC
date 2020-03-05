using POC.Channel;
using POC.Web.AuthenticationService;
using POC.Web.Common;
using System.Web.Mvc;

namespace POC.Web.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
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
            var autheticationUser = authenticationService.GetUser();

            if (autheticationUser != null)
            {
                return;
            }

            var userProvider = AuthenticationServiceFactory.GetUserProvider(filterContext.HttpContext);
            var user = userProvider.GetUser();

            if (user != null)
            {
                authenticationService.LoginUser(user);
                return;
            }

            var authenticationRedirectAddress = new EnviromentLocatedAddress(IdentityDefaults.IdentityUrl);
            filterContext.Result = new RedirectResult(authenticationRedirectAddress.Url);
        }
    }
}