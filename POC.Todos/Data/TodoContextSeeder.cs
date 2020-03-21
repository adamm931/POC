using POC.Todos.Domain;
using System.Data.Entity;
using System.Linq;

namespace POC.Todos.Data
{
    public class TodoContextSeeder : CreateDatabaseIfNotExists<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            var items1_4 = Enumerable
                .Range(1, 4)
                .Select(index => new TodoItem($"Task {index}"));

            var items4_8 = Enumerable
                .Range(4, 8)
                .Select(index => new TodoItem($"Task {index}"));

            var items8_12 = Enumerable
                .Range(8, 12)
                .Select(index => new TodoItem($"Task {index}"));

            var userTodoItems = new[]
            {
                    new UserTodoItems("Adam1993", items1_4),
                    new UserTodoItems("Mario1993", items1_4),
                    new UserTodoItems("Neni1996", items1_4)
                };

            context.UserTodos.AddRange(userTodoItems);
        }
    }
}
