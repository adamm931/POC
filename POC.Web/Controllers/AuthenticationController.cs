using POC.Channel;
using POC.Web.AuthenticationService;
using POC.Web.Common;
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

            var logout = new EnviromentLocatedAddress(IdentityDefaults.IdentityUrl);

            return Redirect(logout.Url);
        }
    }
}