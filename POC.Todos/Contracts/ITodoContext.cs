using POC.Todos.Domain;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Contracts
{
    public interface ITodoContext
    {
        DbSet<TodoItem> Todos { get; }

        DbSet<UserTodoItems> UserTodos { get; }

        Task<bool> UserExists(string user);

        Task<UserTodoItems> GetUserTodos(string user);

        Task Save();
    }
}
