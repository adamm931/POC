using POC.Accounts.Service.Contracts;
using POC.Accounts.Service.Model;
using POC.Channel;
using POC.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService => ChannelManager.Instance.GetAccountService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var username = User.Identity.Name;
            var serviceResponse = await AccountService.GetAccountByUsername(username);
            var account = serviceResponse.Response;

            var model = new AccountViewModel
            {
                Header = new AccountHeaderViewModel
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    MiddleName = account.MiddleName,
                    Gender = account.Gender,
                    BirthDay = account.BirthDay,
                },
                Address = new AccountAddressViewModel
                {
                    Street = account.Address.Street,
                    City = account.Address.City,
                    ZipCode = account.Address.ZipCode,
                    Region = account.Address.Region,
                    Phone = account.Address.Phone,
                    Email = account.Address.Email,
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(AccountViewModel model)
        {
            var username = User.Identity.Name;
            var serviceResponse = await AccountService.GetAccountByUsername(username);
            var account = serviceResponse.Response;

            var accountHeaderRequest = new AccountHeaderServiceRequest
            {
                AccountId = account.Id,
                FirstName = model.Header.FirstName,
                MiddleName = model.Header.MiddleName,
                LastName = model.Header.LastName,
                Gender = model.Header.Gender,
                BirthDay = model.Header.BirthDay
            };

            await AccountService.UpdateAccountHeaderAsync(accountHeaderRequest);

            var accountAddressRequest = new AccountAddressServiceRequest
            {
                AccountId = account.Id,
                Street = model.Address.Street,
                City = model.Address.City,
                ZipCode = model.Address.ZipCode,
                Region = model.Address.Region,
                Phone = model.Address.Phone,
                Email = model.Address.Email
            };

            await AccountService.UpdateAccountAddressAsync(accountAddressRequest);

            return RedirectToAction("Index");
        }
    }
}