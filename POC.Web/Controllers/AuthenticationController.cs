using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Channel;
using POC.Common.Enviroment;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.Models;
using POC.Identity.Web.Authentication;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Service.Contracts;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{

    public class AuthenticationController : BaseController
    {
        private IAuthenticationService AuthenticationService =>
            AuthenticationServiceFactory.GetAutheticationService(HttpContext);

        private readonly IIdentityService IdentityService = ChannelManager.Instance.GetIdentityService();

        private readonly ITodoService TodoService = ChannelManager.Instance.GetTodoService();

        private readonly IAccountService AccountService = ChannelManager.Instance.GetAccountService();

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
            await TodoService.UpdateUserAsync(Username, model.Username);

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