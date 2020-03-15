using POC.Identity.Domain.Entities;
using POC.Identity.Domain.Enums;
using System.Data.Entity.ModelConfiguration;
using static POC.Identity.Domain.Entities.CredentialRule;

namespace POC.Identity.Data.Configurations
{
    public class CredentialRuleConfiguration : EntityTypeConfiguration<CredentialRule>
    {
        public CredentialRuleConfiguration()
        {
            Ignore(model => model.RuleType);

            Map<MinimumLenghtRule>(rule => rule.Requires("RuleType")
                .HasValue(CredentialRuleType.MinimumLenght));

            Map<RequireAlphaNumericCharathersRule>(rule => rule.Requires("RuleType")
                .HasValue(CredentialRuleType.RequireAlphaNumeric));

            Map<RequireSpecialCharathersRule>(rule => rule.Requires("RuleType")
                .HasValue(CredentialRuleType.RequireSpecialCharater));

            Property(model => model.CredentialType.Value)
                .HasColumnName("CredentialType");

            HasMany(model => model.Attributes)
                .WithRequired(attr => attr.CredentialRule)
                .HasForeignKey(attr => attr.CredentialRuleId);
        }
    }
}
