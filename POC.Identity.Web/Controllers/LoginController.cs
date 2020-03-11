﻿using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
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

        private IAccountService AccountService => ChannelManager.Instance.GetAccountService();

        private IRedirectUrlComposer RedirectUrlComposer => new RedirectUrlComposer();

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // password match check
            if (model.PasswordsMismatch)
            {
                ModelState.AddModelError("Password", "Password and confirm password are not same");
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
                ModelState.AddModelError("Username", "Username is not available");
                return View(model);
            }

            // signup
            var signupRequest = new SignupUserServiceRequest
            {
                Username = model.Username,
                Password = model.Password
            };

            await IdentityService.SignupAsync(signupRequest);

            // add user
            await TodoService.AddUserAsync(model.Username);

            // add account login
            var accountLoginRequest = new AccountLoginServiceRequest
            {
                Username = request.Username
            };

            await AccountService.AddAccountLoginAsync(accountLoginRequest);

            // redirect
            var url = RedirectUrlComposer.ComposeUrl(model.Username);

            return Redirect(url);
        }
    }
}