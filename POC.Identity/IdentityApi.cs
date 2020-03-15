using POC.Identity.Contracts;
using POC.Identity.Data;
using POC.Identity.Domain.Entities;
using POC.Identity.Domain.Enums;
using POC.Identity.Exceptions;
using POC.Identity.Internal;
using POC.Identity.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity
{
    public class IdentityApi : IIdentityApi
    {
        private readonly IdentityContext Context;
        private readonly ICredentialValidator CredentialValidator;

        public IdentityApi()
        {
            IdentityConfig.UseBase64Encryption();
            IdentityConfig.UseSha256ManagedHashing();

            Context = new IdentityContext();
            CredentialValidator = new CredentialValidator(Context);
        }

        public async Task<CheckUsernameResponse> CheckUsernameAsync(CheckUsernameRequest request)
        {
            using (Context)
            {
                bool exists = await UsernameExists(request.Username);

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

        public async Task UpdateLoginAsync(UpdateUserLoginRequest request)
        {
            using (var context = new IdentityContext())
            {
                await ValidateUsername(request.NewUsername);
                await ValidatePassword(request.NewPassword);

                bool exists = await UsernameExists(request.NewUsername);

                if (exists)
                {
                    return;
                }

                var login = await context
                    .UserLogins
                    .SingleAsync(item => item.Username.Value == request.Username);

                login.Update(request.NewUsername, request.NewPassword);

                await context.SaveChangesAsync();
            }
        }

        public async Task SignupAsync(SignupUserRequest request)
        {
            using (var context = new IdentityContext())
            {
                await ValidateUsername(request.Username);
                await ValidatePassword(request.Password);

                bool exists = await UsernameExists(request.Username);

                if (exists)
                {
                    return;
                }

                context.UserLogins.Add(new UserLogin(request.Username, request.Password));

                await context.SaveChangesAsync();
            }
        }

        private async Task<bool> UsernameExists(string username)
        {
            return await Context.UserLogins.AnyAsync(login => login.Username.Value == username);
        }

        private async Task ValidateUsername(string username)
        {
            var usernameValidation = await CredentialValidator.Validate(CredentialType.Username, username);

            if (!usernameValidation.IsValid)
            {
                throw new CredentialValidationException(usernameValidation);
            }
        }

        private async Task ValidatePassword(string password)
        {
            var usernameValidation = await CredentialValidator.Validate(CredentialType.Password, password);

            if (!usernameValidation.IsValid)
            {
                throw new CredentialValidationException(usernameValidation);
            }
        }
    }
}
