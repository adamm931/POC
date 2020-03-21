using POC.Identity.Contracts;
using POC.Identity.Domain.Enums;
using POC.Identity.Domain.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Internal
{
    public class CredentialRequirmentValidator : ICredentialRequirmentValidator
    {
        public CredentialRequirmentValidator(IIdentityContext identityContext)
        {
            IdentityContext = identityContext;
        }

        public IIdentityContext IdentityContext { get; }

        public async Task<CredentialRequirmentValidationResult> ValidateAsync(CredentialType credentialType, string value)
        {
            var credentialRules = await IdentityContext
                .CredentialRules
                .Include(model => model.Attributes)
                .ToListAsync();

            var invalidResults = credentialRules
                .Where(rule => rule.CredentialType == credentialType)
                .Select(rule => rule.Validate(value))
                .Where(ret => !ret.IsValid);

            var result = new CredentialRequirmentValidationResult(credentialType);

            foreach (var ret in invalidResults)
            {
                result.AddValidationError(ret.Message);
            }

            return result;
        }
    }
}
