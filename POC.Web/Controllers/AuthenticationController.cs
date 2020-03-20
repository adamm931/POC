﻿using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Common.Enviroment;
using POC.Configuration.Mapping;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.UseCases.UpdateLogin;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Todos.Service.Contracts;
using POC.Todos.Service.UseCases.UpdateUser;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{

    public class AuthenticationController : BaseController
    {
        public AuthenticationController(
            IAccountService accountService,
            IIdentityService identityService,
            ITodoService todoService,
            IAuthenticationService authenticationService,
            IMapping mapper) : base(accountService, identityService, todoService, authenticationService, mapper)
        {
        }

        [HttpGet]
        public ActionResult UpdateLogin()
        {
            var model = new UpdateLoginViewModel
            {
                Username = Username
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateLogin(UpdateLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // update identity user
            var updateUserLoginRequest = Mapper.Map<UpdateUserLoginServiceRequest>(model);
            updateUserLoginRequest.Username = Username;
            await IdentityService.UpdateLoginAsync(updateUserLoginRequest);

            // update todos user
            await TodoService.UpdateUserAsync(new UpdateUserServiceRequest
            {
                Username = Username,
                NewUsername = model.Username
            });

            // update account user
            var updateAccountLoginRequest = Mapper.Map<UpdateAccountLoginServiceRequest>(model);
            updateAccountLoginRequest.AccountUsername = Username;
            await AccountService.UpdateAccountLoginAsync(updateAccountLoginRequest);

            return RedirectToAction("Logout");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationService.LogoutUser();

            var url = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.IdentityUrl);

            return Redirect(url);
        }
    }
}