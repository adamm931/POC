using POC.Identity.Contracts;
using POC.Identity.Data;
using POC.Identity.Domain;
using POC.Identity.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Internal
{
    internal class UserService : IUserService
    {
        public async Task<CheckUsernameResponse> CheckUsernameAsync(CheckUsernameRequest request)
        {
            using (var context = new IdentityContext())
            {
                bool exists = await UsernameExists(request.Username, context);

                return new CheckUsernameResponse
                {
                    IsAvailable = !exists
                };
            }
        }

        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            using (var context = new IdentityContext())
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

        public async Task SignupAsync(SignupUserRequest request)
        {
            using (var context = new IdentityContext())
            {
                bool exists = await UsernameExists(request.Username, context);

                if (exists)
                {
                    return;
                }

                context.UserLogins.Add(UserLogin.Create(request.Username, request.Password));

                await context.SaveChangesAsync();
            }
        }

        private async Task<bool> UsernameExists(string username, IdentityContext context)
        {
            return await context.UserLogins.AnyAsync(login => login.Username == username);
        }
    }
}
