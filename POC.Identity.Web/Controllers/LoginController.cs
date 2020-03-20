using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.UseCases.Login;
using POC.Identity.Service.UseCases.Signup;
using POC.Identity.Web.Authentication.Models;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.Models;
using POC.Todos.Service.Contracts;
using POC.Todos.Service.UseCases.AddUser;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Identity.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ITodoService _todoService;
        private readonly IAccountService _accountService;
        private readonly IRedirectUrlProvider _redirectUrlProvider;
        private readonly IUserSession _userSession;

        public LoginController(
            IIdentityService identityService,
            ITodoService todoService,
            IAccountService accountService,
            IRedirectUrlProvider redirectUrlProvider,
            IUserSession userSession)
        {
            _identityService = identityService;
            _todoService = todoService;
            _accountService = accountService;
            _redirectUrlProvider = redirectUrlProvider;
            _userSession = userSession;
        }

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

            var result = await _identityService.LoginAsync(request);

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

            _userSession.EnstablishSession(userSession);

            return Redirect(_redirectUrlProvider.RedirectUrl);
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

            await _identityService.SignupAsync(signupRequest);

            // add user
            await _todoService.AddUserAsync(new AddUserServiceRequest
            {
                Username = signupUsername
            });

            // add account login
            var accountLoginRequest = new AddAccountLoginServiceRequest
            {
                Username = signupUsername
            };

            await _accountService.AddAccountLoginAsync(accountLoginRequest);

            // begin session
            var userSession = new UserSessionModel
            {
                Username = signupUsername
            };

            _userSession.EnstablishSession(userSession);

            return Redirect(_redirectUrlProvider.RedirectUrl);
        }
    }
}