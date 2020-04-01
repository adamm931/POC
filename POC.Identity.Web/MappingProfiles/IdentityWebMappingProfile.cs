using AutoMapper;
using POC.Identity.Service.UseCases.Signup;
using POC.Identity.Web.Authentication.Models;
using POC.Identity.Web.Models;

namespace POC.Identity.Web.MappingProfiles
{
    public class IdentityWebMappingProfile : Profile
    {
        public IdentityWebMappingProfile()
        {
            CreateMap<UserLoginModel, UserSessionModel>();
            CreateMap<UserSignupModel, SignupUserServiceRequest>();
            CreateMap<UserSignupModel, UserSessionModel>();
        }
    }
}