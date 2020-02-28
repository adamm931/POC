using POC.Service.Common;
using POC.Service.Contracts;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Service.Data
{
    public class TodoItemContext : DbContext, ITodosProvider, ITodosAsyncProvider
    {
        public virtual DbSet<TodoItem> Todos { get; set; }

        public static TodoItemContext Create() => new TodoItemContext();

        private TodoItemContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new TodoItemContext.Seeder());
        }

        #region Connection String

        public static string GetConnectionString()
        {
            var host = EnviromentVariablesFetcher.GetVaraiable("TodoDbHost");
            var port = EnviromentVariablesFetcher.GetVaraiable("TodoDbPort");
            var saPassword = EnviromentVariablesFetcher.GetVaraiable("TodoDbSaPassword");

            return $"Server={host},{port};Database=TodoItems;User ID=sa;Password={saPassword}";
        }

        #endregion

        #region Seeder

        private class Seeder : CreateDatabaseIfNotExists<TodoItemContext>
        {
            protected override void Seed(TodoItemContext context)
            {
                var items = Enumerable
                    .Range(1, 10)
                    .Select(index => new TodoItem($"Task {index}"));

                context.Todos.AddRange(items);
            }
        }

        #endregion

        #region ITodosProvider

        public TodoItem AddTodo(string name)
        {
            var todo = Todos.Add(new TodoItem(name));

            SaveChanges();

            return todo;
        }

        public TodoItem CompleteTodo(Guid id)
        {
            var todo = GetTodo(id);

            todo?.Complete();

            SaveChanges();

            return todo;
        }

        public TodoItem OpenTodo(Guid id)
        {
            var todo = GetTodo(id);

            todo?.Open();

            SaveChanges();

            return todo;
        }

        public void DeleteTodo(Guid id)
        {
            Todos.Remove(GetTodo(id));

            SaveChanges();
        }

        public List<TodoItem> ListTodos() => Todos
            .OrderByDescending(item => item.CreatedAt)
            .ToList();

        private TodoItem GetTodo(Guid id) => Todos.FirstOrDefault(item => item.Id == id);

        #endregion

        #region ITodosAsyncProvider

        public async Task<TodoItem> AddTodoAsync(string name)
        {
            var todo = Todos.Add(new TodoItem(name));

            await SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> CompleteTodoAsync(Guid guid)
        {
            var todo = GetTodo(guid);

            todo?.Complete();

            await SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> OpenTodoAsync(Guid guid)
        {
            var todo = GetTodo(guid);

            todo?.Open();

            await SaveChangesAsync();

            return todo;
        }

        public async Task DeleteTodoAsync(Guid guid)
        {
            Todos.Remove(GetTodo(guid));

            await SaveChangesAsync();
        }

        public async Task<List<TodoItem>> ListTodosAsync()
        {
            return await Todos
                .OrderByDescending(item => item.CreatedAt)
                .ToListAsync();
        }

        #endregion
    }
}