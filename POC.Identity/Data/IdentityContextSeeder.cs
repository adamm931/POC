using POC.Identity.Domain.Entities;
using POC.Identity.Domain.Enums;
using System.Data.Entity;
using static POC.Identity.Domain.Entities.CredentialRule;

namespace POC.Identity.Data
{
    public class IdentityContextSeeder : CreateDatabaseIfNotExists<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            var passwordRules = new CredentialRule[]
            {
                new MinimumLenghtRule(CredentialType.Password,
                    new CredentialRuleAttribute(CredentialRuleType.MinimumLenght, "12")
                    ),
                new RequireAlphaNumericCharathersRule(CredentialType.Password),
                new RequireSpecialCharathersRule(CredentialType.Password),
            };

            var usernameRules = new CredentialRule[]
            {
                new MinimumLenghtRule(CredentialType.Username,
                    new CredentialRuleAttribute(CredentialRuleType.MinimumLenght, "8")
                    ),
                new RequireAlphaNumericCharathersRule(CredentialType.Username),
            };

            context.CredentialRules.AddRange(passwordRules);
            context.CredentialRules.AddRange(usernameRules);

            context.Logins.AddRange(new[]
            {
                new UserLogin("Adam1993", "Password1234!"),
                new UserLogin("Mario1993", "Password1234!"),
                new UserLogin("Neni1996", "Password1234!")
            });
        }
    }
}
