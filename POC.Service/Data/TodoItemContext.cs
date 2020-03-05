using POC.Common;
using POC.Service.Contracts;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Service.Data
{
    public class TodoItemContext : DbContext, ITodosProvider
    {
        public virtual DbSet<TodoItem> Todos { get; set; }

        public virtual DbSet<UserTodoItems> UserTodoItems { get; set; }

        public static TodoItemContext Create() => new TodoItemContext();

        private TodoItemContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new TodoItemContext.Seeder());
        }

        #region OnModelConfiguring

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        #endregion

        #region Connection String

        public static string GetConnectionString()
        {
            var builder = new SqlServerConnectionStringBuilder();

            var variables = new ConnectionStringVariables(
                EnviromentConnectionStringVariable.Host("TodoDbHost"),
                EnviromentConnectionStringVariable.Port("TodoDbPort"),
                EnviromentConnectionStringVariable.Password("TodoDbSaPassword"),
                InlineConnectionStringVariable.User("sa"),
                InlineConnectionStringVariable.DbName("TodoItemsDb"));

            var connectionString = new ConnectionStringResolver(builder, variables)
                .GetConnectionString();

            return connectionString.Value;
        }

        #endregion

        #region Seeder

        private class Seeder : CreateDatabaseIfNotExists<TodoItemContext>
        {
            protected override void Seed(TodoItemContext context)
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
                    new UserTodoItems("Adam", items1_4),
                    new UserTodoItems("Adam123", items1_4),
                    new UserTodoItems("Adam0905", items1_4)
                };

                context.UserTodoItems.AddRange(userTodoItems);
            }
        }

        #endregion

        #region ITodosProvider

        public async Task<TodoItem> AddTodoAsync(string name, string user)
        {
            var userTodos = await GetUserTodos(user);

            var todo = userTodos.AddTodo(name);

            await SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> CompleteTodoAsync(Guid guid, string user)
        {
            var userTodos = await GetUserTodos(user);

            var todo = userTodos?.CompleteTodo(guid);

            await SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> OpenTodoAsync(Guid guid, string user)
        {
            var userTodos = await GetUserTodos(user);

            var todo = userTodos?.OpenTodo(guid);

            await SaveChangesAsync();

            return todo;
        }

        public async Task DeleteTodoAsync(Guid guid, string user)
        {
            var userTodos = await GetUserTodos(user);

            var deletedTodo = userTodos?.DeleteTodo(guid);

            Todos.Remove(deletedTodo);

            await SaveChangesAsync();
        }

        public async Task<List<TodoItem>> ListTodosAsync(string user)
        {
            var userTodos = await GetUserTodos(user);

            return userTodos.TodoItems
                .OrderByDescending(item => item.CreatedAt)
                .ToList();
        }

        #endregion

        #region Helpers

        private async Task<UserTodoItems> GetUserTodos(string user)
        {
            return await UserTodoItems
                .Include(item => item.TodoItems)
                .SingleAsync(userItems => userItems.Username == user);
        }

        #endregion
    }
}