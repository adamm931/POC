using POC.Common.Connection;
using POC.Common.Data;
using POC.Todos.Contracts;
using POC.Todos.Domain;
using System.Data.Entity;

namespace POC.Todos.Data
{
    public class TodoContext : BaseDbContext<TodoContext>, ITodoContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public DbSet<UserTodoItems> UserTodos { get; set; }

        public TodoContext(
            IConnectionString connectionString,
            IDatabaseInitializer<TodoContext> databaseInitializer)
            : base(connectionString, databaseInitializer)
        {
        }
    }
}