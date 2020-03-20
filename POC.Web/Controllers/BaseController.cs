using POC.Accounts.Service.Contracts;
using POC.Configuration.Mapping;
using POC.Identity.Service.Contracts;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Todos.Service.Contracts;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string Username => User.Identity.Name;

        protected IAccountService AccountService { get; }

        protected IIdentityService IdentityService { get; }

        protected ITodoService TodoService { get; }

        protected IAuthenticationService AuthenticationService { get; }

        protected IMapping Mapper { get; }

        protected BaseController(
            IAccountService accountService,
            IIdentityService identityService,
            ITodoService todoService,
            IAuthenticationService authenticationService,
            IMapping mapper)
        {
            AccountService = accountService;
            IdentityService = identityService;
            TodoService = todoService;
            AuthenticationService = authenticationService;
            Mapper = mapper;
        }
    }
}