using POC.Identity.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace POC.Identity.Data.Configurations
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            Property(model => model.Password.Hash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            Property(model => model.Password.Salt)
                .HasColumnName("PasswordSalt")
                .IsRequired();

            Property(model => model.Username.Value)
                .HasColumnName("Username")
                .IsRequired();
        }
    }
}
