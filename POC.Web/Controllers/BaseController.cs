using POC.Common.Mapper;
using POC.Web.MappingProfiles;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string Username => User.Identity.Name;

        protected readonly IMapping Mapper = Mapping.Create(new MappingProfile());
    }
}