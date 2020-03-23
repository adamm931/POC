using POC.Common.Connection;
using POC.Common.Data;
using POC.Todos.Contracts;
using POC.Todos.Domain;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public async Task<bool> UserExists(string user)
        {
            return await UserTodos.AnyAsync(item => item.Username == user);
        }

        public async Task<UserTodoItems> GetUserTodos(string user)
        {
            return await UserTodos
                .Include(item => item.TodoItems)
                .SingleOrDefaultAsync(item => item.Username == user);
        }
    }
}