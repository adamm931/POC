using POC.Common.Enviroment;
using POC.Identity.Web.Authentication;
using POC.Identity.Web.AuthenticationService.Contracts;
using System.Web.Mvc;

namespace POC.Web.Controllers
{

    public class AuthenticationController : Controller
    {
        private IAuthenticationService AuthenticationService =>
            AuthenticationServiceFactory.GetAutheticationService(HttpContext);

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationService.LogoutUser();

            var url = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.IdentityUrl);

            return Redirect(url);
        }
    }
}