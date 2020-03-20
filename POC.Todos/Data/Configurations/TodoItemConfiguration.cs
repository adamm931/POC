using POC.Todos.Domain;
using System.Data.Entity.ModelConfiguration;

namespace POC.Todos.Data.Configurations
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