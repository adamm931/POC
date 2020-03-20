using POC.Todos.Domain;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Todos.Contracts
{
    public interface ITodoContext
    {
        DbSet<TodoItem> Todos { get; }

        DbSet<UserTodoItems> UserTodos { get; }

        Task Save();
    }
}
