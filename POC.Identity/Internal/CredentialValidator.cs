using POC.Identity.Contracts;
using POC.Identity.Data;
using POC.Identity.Domain.Enums;
using POC.Identity.Domain.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Internal
{
    public class CredentialValidator : ICredentialValidator
    {
        public CredentialValidator(IdentityContext context)
        {
            Context = context;
        }

        public IdentityContext Context { get; }

        public async Task<CredentialValidationResult> Validate(CredentialType credentialType, string value)
        {
            var credentialRules = await Context
                .CredentialRules
                .Include(model => model.Attributes)
                .ToListAsync();

            var invalidResults = credentialRules
                .Where(rule => rule.CredentialType == credentialType)
                .Select(rule => rule.Validate(value))
                .Where(ret => !ret.IsValid);

            var result = new CredentialValidationResult(credentialType);

            foreach (var ret in invalidResults)
            {
                result.AddValidationError(ret.Message);
            }

            return result;
        }
    }
}
