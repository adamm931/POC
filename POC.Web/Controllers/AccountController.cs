using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Channel;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService = ChannelManager.Instance.GetAccountService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var serviceResponse = await AccountService.GetAccountByUsername(Username);
            var account = serviceResponse.Response;

            var model = Mapper.Map<AccountViewModel>(account);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(AccountViewModel model)
        {
            var accountHeaderRequest = Mapper.Map<AccountHeaderServiceRequest>(model.Header);
            accountHeaderRequest.AccountUsername = Username;
            await AccountService.UpdateAccountHeaderAsync(accountHeaderRequest);

            var accountAddressRequest = Mapper.Map<AccountAddressServiceRequest>(model.Address);
            accountAddressRequest.AccountUsername = Username;
            await AccountService.UpdateAccountAddressAsync(accountAddressRequest);

            return RedirectToAction("Index");
        }
    }
}