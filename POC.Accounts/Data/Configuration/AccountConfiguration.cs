using POC.Accounts.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Accounts.Data.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            Property(model => model.Gender.Value)
                .HasColumnName("Gender");

            Property(model => model.BirthDay)
                .HasColumnType("Date");

            HasOptional(model => model.Address)
                .WithRequired(address => address.Account);

            HasOptional(model => model.Login)
                 .WithRequired(address => address.Account);
        }
    }
}
