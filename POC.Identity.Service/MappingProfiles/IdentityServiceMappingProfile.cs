using AutoMapper;
using POC.Identity.Models;
using POC.Identity.Service.Models;

namespace POC.Identity.Service.MappingProfiles
{
    public class IdentityServiceMappingProfile : Profile
    {
        public IdentityServiceMappingProfile()
        {
            CreateMap<CheckUsernameServiceRequest, CheckUsernameRequest>();
            CreateMap<CheckUsernameResponse, CheckUsernameServiceResponse>();
            CreateMap<UserLoginServiceRequest, UserLoginRequest>();
            CreateMap<UserLoginResponse, UserLoginServiceResponse>();
            CreateMap<SignupUserServiceRequest, SignupUserRequest>();
        }
    }
}