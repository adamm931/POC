using POC.Channel;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.Models;
using POC.Identity.Web.Common;
using POC.Identity.Web.Models;
using POC.Identity.Web.Service;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Identity.Web.Controllers
{
    public class LoginController : Controller
    {
        private IIdentityService IdentityService => ChannelManager.Instance
            .GetChannel<IIdentityService>(new EnviromentLocatedAddress(IdentityDefaults.IdentityServiceUrl));

        private IRedirectUrlComposer RedirectUrlComposer => new RedirectUrlComposer();

        [HttpGet]
        public ActionResult Index()
        {
            return View(UserLoginModel.Empty);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserLoginModel model)
        {
            var request = new UserLoginServiceRequest
            {
                Username = model.Username,
                Password = model.Password
            };

            var result = await IdentityService.LoginAsync(request);

            if (!result.IsSuccess)
            {
                throw new Exception(result.FailReason);
            }

            if (!result.Response.IsAuthenticated)
            {
                model.FailedLogin = true;
                model.FailedLoginMessage = "Invalid username or password";

                return View(model);
            }

            var url = RedirectUrlComposer.ComposeUrl(model.Username);
            return Redirect(url);
        }
    }
}