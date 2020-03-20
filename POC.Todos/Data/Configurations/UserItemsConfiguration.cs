using POC.Todos.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Todos.Data.Configurations
{
    public class UserItemsConfiguration : EntityTypeConfiguration<UserTodoItems>
    {
        public UserItemsConfiguration()
        {
            Property(model => model.Username)
                .HasMaxLength(50)
                .IsRequired();

            HasIndex(model => model.Username)
                .IsUnique();
        }
    }
}