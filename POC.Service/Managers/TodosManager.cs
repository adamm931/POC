using POC.Service.Contracts;
using POC.Service.Data;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Service.Managers
{
    public class TodosManager : ITodoManager
    {
        private readonly TodoItemContext Context = TodoItemContext.Create();

        public async Task<TodoItem> AddTodoAsync(string name, string user)
        {
            using (Context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos.AddTodo(name);

                await Context.SaveChangesAsync();

                return todo;
            }
        }

        public async Task<TodoItem> CompleteTodoAsync(Guid guid, string user)
        {
            using (Context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos?.CompleteTodo(guid);

                await Context.SaveChangesAsync();

                return todo;
            }
        }

        public async Task DeleteTodoAsync(Guid guid, string user)
        {
            using (Context)
            {
                var userTodos = await GetUserTodos(user);

                var deletedTodo = userTodos?.DeleteTodo(guid);

                Context.Todos.Remove(deletedTodo);

                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoItem>> ListTodosAsync(string user)
        {
            using (Context)
            {
                var userTodos = await GetUserTodos(user);

                return userTodos?.TodoItems
                    .OrderByDescending(item => item.CreatedAt)
                    .ToList() ?? new List<TodoItem>();
            }
        }

        public async Task<TodoItem> OpenTodoAsync(Guid guid, string user)
        {
            using (Context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos?.OpenTodo(guid);

                await Context.SaveChangesAsync();

                return todo;
            }
        }

        public async Task AddUserAsync(string user)
        {
            using (Context)
            {
                Context.UserTodoItems.Add(new UserTodoItems(user));

                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(string user, string newUser)
        {
            using (Context)
            {
                var userItem = await Context.UserTodoItems
                    .SingleOrDefaultAsync(item => item.Username == user);

                userItem.UpdateUser(newUser);

                await Context.SaveChangesAsync();
            }
        }

        private async Task<UserTodoItems> GetUserTodos(string user)
        {
            return await Context.UserTodoItems
                .Include(item => item.TodoItems)
                .FirstOrDefaultAsync(userItems => userItems.Username == user);
        }

    }
}