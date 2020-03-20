using POC.Common.Connection;
using POC.Todos.Contracts;
using POC.Todos.Domain;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Todos.Data
{
    public class TodoContext : DbContext, ITodoContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public DbSet<UserTodoItems> UserTodos { get; set; }

        public TodoContext(IConnectionString connectionString) : base(connectionString.Value)
        {
            Database.SetInitializer(new Seeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        public async Task Save()
        {
            await base.SaveChangesAsync();
        }

        private class Seeder : CreateDatabaseIfNotExists<TodoContext>
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
}