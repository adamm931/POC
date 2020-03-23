using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.UseCases.UpdateAccountAddress;
using POC.Accounts.Service.UseCases.UpdateAccountHeader;
using POC.Configuration.Mapping;
using POC.Identity.Service.Contracts;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Todos.Service.Contracts;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(
            IAccountService accountService,
            IIdentityService identityService,
            ITodoService todoService,
            IAuthenticationService authenticationService,
            IMapping mapper)
            : base(accountService, identityService, todoService, authenticationService, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var serviceResponse = await AccountService.GetAccountByUsernameAsync(Username);
            var account = serviceResponse.Response;

            var model = Mapper.Map<AccountViewModel>(account);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(AccountViewModel model)
        {
            var accountHeaderRequest = Mapper.Map<UpdateAccountHeaderServiceRequest>(model.Header);
            accountHeaderRequest.AccountUsername = Username;
            await AccountService.UpdateAccountHeaderAsync(accountHeaderRequest);

            var accountAddressRequest = Mapper.Map<UpdateAccountAddressServiceRequest>(model.Address);
            accountAddressRequest.AccountUsername = Username;
            await AccountService.UpdateAccountAddressAsync(accountAddressRequest);

            return RedirectToAction("Index");
        }
    }
}