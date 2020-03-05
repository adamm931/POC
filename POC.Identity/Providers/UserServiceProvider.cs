using POC.Identity.Contracts;
using POC.Identity.Internal;

namespace POC.Identity.Providers
{
    public class UserServiceProvider
    {
        public static IUserService GetUserService() => new UserService();
    }
}
