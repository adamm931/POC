using POC.Accounts.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Accounts.Data.Configuration
{
    public class AccountLoginConfiguration : EntityTypeConfiguration<AccountLogin>
    {
        public AccountLoginConfiguration()
        {
            Property(model => model.Username)
                .HasMaxLength(50)
                .IsRequired();

            HasIndex(model => model.Username)
                .IsUnique();
        }
    }
}
