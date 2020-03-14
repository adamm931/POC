using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Channel;
using POC.Common.Mapper;
using POC.Web.MappingProfiles;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService AccountService = ChannelManager.Instance.GetAccountService();

        private readonly Mapping Mapping = Mapping.Create(new MappingProfile());

        private string Username => User.Identity.Name;

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var serviceResponse = await AccountService.GetAccountByUsername(Username);
            var account = serviceResponse.Response;

            var model = Mapping.Map<AccountViewModel>(account);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(AccountViewModel model)
        {
            var accountHeaderRequest = Mapping.Map<AccountHeaderServiceRequest>(model.Header);
            accountHeaderRequest.AccountUsername = Username;
            await AccountService.UpdateAccountHeaderAsync(accountHeaderRequest);

            var accountAddressRequest = Mapping.Map<AccountAddressServiceRequest>(model.Address);
            accountAddressRequest.AccountUsername = Username;
            await AccountService.UpdateAccountAddressAsync(accountAddressRequest);

            return RedirectToAction("Index");
        }
    }
}