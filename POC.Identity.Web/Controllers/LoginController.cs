using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Channel;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.Models;
using POC.Identity.Web.Authentication;
using POC.Identity.Web.Authentication.Models;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.Models;
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

        private IAccountService AccountService => ChannelManager.Instance.GetAccountService();

        private IRedirectUrlProvider RedirectUrlProvider => AuthenticationServiceFactory.GetRedirectUrlProvider();

        private IUserSession UserSession => AuthenticationServiceFactory.GetUserSession(HttpContext);

        [HttpGet]
        public ActionResult Index()
        {
            return View(UserLoginModel.Empty);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                ModelState.AddModelError("Username", "Invalid username or password");
                return View(model);
            }

            // begin session
            var userSession = new UserSessionModel
            {
                Username = model.Username
            };

            UserSession.EnstablishSession(userSession);

            return Redirect(RedirectUrlProvider.RedirectUrl);
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(UserSignupModel.Empty);
        }

        [HttpPost]
        public async Task<ActionResult> Signup(UserSignupModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var signupUsername = model.Username;
            var signupPassowrd = model.Password;

            // signup
            var signupRequest = new SignupUserServiceRequest
            {
                Username = signupUsername,
                Password = signupPassowrd
            };

            await IdentityService.SignupAsync(signupRequest);

            // add user
            await TodoService.AddUserAsync(signupUsername);

            // add account login
            var accountLoginRequest = new AddAccountLoginServiceRequest
            {
                Username = signupUsername
            };

            await AccountService.AddAccountLoginAsync(accountLoginRequest);

            // begin session
            var userSession = new UserSessionModel
            {
                Username = signupUsername
            };

            UserSession.EnstablishSession(userSession);

            return Redirect(RedirectUrlProvider.RedirectUrl);
        }
    }
}