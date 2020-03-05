using POC.Identity.Contracts;
using POC.Identity.Data;
using POC.Identity.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Internal
{
    internal class UserService : IUserService
    {
        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            using (var context = new TodoIdentityContext())
            {
                var logins = await context
                    .UserLogins
                    .ToListAsync();

                return new UserLoginResponse
                {
                    IsAuthenticated = logins.Any(login => login.Challenge(request.Username, request.Password))
                };
            }
        }
    }
}
