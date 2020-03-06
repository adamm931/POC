using POC.Channel;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.Models;
using POC.Identity.Web.Models;
using POC.Identity.Web.Service;
using POC.Service.Contracts;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Identity.Web.Controllers
{
    public class LoginController : Controller
    {
        private IIdentityService IdentityService => ChannelManager.Instance.GetIdentityService();

        private ITodoService TodoService => ChannelManager.Instance.GetTodoService();

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
                model.SetFailMessage("Invalid username or password");

                return View(model);
            }

            var url = RedirectUrlComposer.ComposeUrl(model.Username);

            return Redirect(url);
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(UserSignupModel.Empty);
        }

        [HttpPost]
        public async Task<ActionResult> Signup(UserSignupModel model)
        {
            // password match check
            if (model.PasswordsMismatch)
            {
                model.SetFailMessage("Password and confirm password are not same");
                return View(model);
            }

            // check username
            var request = new CheckUsernameServiceRequest
            {
                Username = model.Username,
            };

            var result = await IdentityService.CheckUsernameAsync(request);

            if (!result.IsSuccess)
            {
                throw new Exception(result.FailReason);
            }

            if (!result.Response.IsAvailable)
            {
                model.SetFailMessage("Username is not available");
                return View(model);
            }

            if (!result.Response.IsAvailable)
            {
                model.SetFailMessage("Username is not available");
                return View(model);
            }

            // signup
            var signupRequest = new SignupUserServiceRequest
            {
                Username = model.Username,
                Password = model.Password
            };

            var signupResult = await IdentityService.SignupAsync(signupRequest);

            await TodoService.AddUserAsync(model.Username);

            if (!signupResult.IsSuccess)
            {
                throw new Exception(signupResult.FailReason);
            }

            var url = RedirectUrlComposer.ComposeUrl(model.Username);

            return Redirect(url);
        }

    }
}