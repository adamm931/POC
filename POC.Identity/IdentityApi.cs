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
        public IdentityApi()
        {
            IdentityConfig.UseBase64Encryption();
            IdentityConfig.UseSha256ManagedHashing();
        }

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

        public async Task UpdateLoginAsync(UpdateUserLoginRequest request)
        {
            using (var context = new IdentityContext())
            {
                await ValidateUsername(request.NewUsername, context);
                await ValidatePassword(request.NewPassword, context);

                bool exists = await UsernameExists(request.NewUsername, context);

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
                await ValidateUsername(request.Username, context);
                await ValidatePassword(request.Password, context);

                bool exists = await UsernameExists(request.Username, context);

                if (exists)
                {
                    return;
                }

                context.UserLogins.Add(new UserLogin(request.Username, request.Password));

                await context.SaveChangesAsync();
            }
        }

        private async Task<bool> UsernameExists(string username, IdentityContext context)
        {
            return await context.UserLogins.AnyAsync(login => login.Username.Value == username);
        }

        private async Task ValidateUsername(string username, IdentityContext context)
        {
            var credentialValidator = new CredentialValidator(context);
            var usernameValidation = await credentialValidator.Validate(CredentialType.Username, username);

            if (!usernameValidation.IsValid)
            {
                throw new CredentialValidationException(usernameValidation);
            }
        }

        private async Task ValidatePassword(string password, IdentityContext context)
        {
            var credentialValidator = new CredentialValidator(context);
            var usernameValidation = await credentialValidator.Validate(CredentialType.Password, password);

            if (!usernameValidation.IsValid)
            {
                throw new CredentialValidationException(usernameValidation);
            }
        }
    }
}
