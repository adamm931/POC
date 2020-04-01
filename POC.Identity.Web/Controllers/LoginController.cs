using POC.Configuration.Mapping;
using POC.Identity.Service.Contracts;
using POC.Identity.Service.UseCases.Signup;
using POC.Identity.Web.Authentication.Models;
using POC.Identity.Web.Authentication.Service;
using POC.Identity.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Identity.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IRedirectUrlProvider _redirectUrlProvider;
        private readonly IUserSession _userSession;
        private readonly IMapping _mapper;

        public LoginController(
            IIdentityService identityService,
            IRedirectUrlProvider redirectUrlProvider,
            IUserSession userSession,
            IMapping mapper)
        {
            _identityService = identityService;
            _redirectUrlProvider = redirectUrlProvider;
            _userSession = userSession;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(UserLoginModel.Empty);
        }

        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // begin session
            var userSession = _mapper.Map<UserSessionModel>(model);
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

            // signup
            var signupRequest = _mapper.Map<SignupUserServiceRequest>(model);
            await _identityService.SignupAsync(signupRequest);

            // begin session
            var userSession = _mapper.Map<UserSessionModel>(model);
            _userSession.EnstablishSession(userSession);

            return Redirect(_redirectUrlProvider.RedirectUrl);
        }
    }
}