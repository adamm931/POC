using POC.Service.Models;
using System.Data.Entity.ModelConfiguration;

namespace POC.Service.Configurations
{
    public class TodoItemConfiguration : EntityTypeConfiguration<TodoItem>
    {
        public TodoItemConfiguration()
        {
            HasRequired(model => model.UserTodoItems)
                .WithMany(model => model.TodoItems)
                .HasForeignKey(model => model.UserTodoItemsId);
        }
    }
}