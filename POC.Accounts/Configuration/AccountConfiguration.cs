using POC.Accounts.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Accounts.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            Property(model => model.Gender.Value)
                .HasColumnName("Gender");

            HasOptional(model => model.Address)
                .WithRequired(address => address.Account);

            HasOptional(model => model.Login)
                 .WithRequired(address => address.Account);
        }
    }
}
