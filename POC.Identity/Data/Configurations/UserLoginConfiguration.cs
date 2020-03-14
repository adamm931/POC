using POC.Identity.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Identity.Data.Configurations
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            Property(model => model.Password.Hash)
                .HasColumnName("PasswordHash");

            Property(model => model.Password.Salt)
                .HasColumnName("PasswordSalt");

            Property(model => model.Username.Value)
                .HasColumnName("Username");
        }
    }
}
