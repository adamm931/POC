using POC.Common;
using POC.Web.AuthenticationService;
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