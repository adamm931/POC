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
        private readonly TodoItemContext _context = TodoItemContext.Create();

        public async Task<TodoItem> AddTodoAsync(string name, string user)
        {
            using (_context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos.AddTodo(name);

                await _context.SaveChangesAsync();

                return todo;
            }
        }

        public async Task AddUser(string user)
        {
            using (_context)
            {
                _context.UserTodoItems.Add(new UserTodoItems(user));

                await _context.SaveChangesAsync();
            }
        }

        public async Task<TodoItem> CompleteTodoAsync(Guid guid, string user)
        {
            using (_context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos?.CompleteTodo(guid);

                await _context.SaveChangesAsync();

                return todo;
            }
        }

        public async Task DeleteTodoAsync(Guid guid, string user)
        {
            using (_context)
            {
                var userTodos = await GetUserTodos(user);

                var deletedTodo = userTodos?.DeleteTodo(guid);

                _context.Todos.Remove(deletedTodo);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoItem>> ListTodosAsync(string user)
        {
            using (_context)
            {
                var userTodos = await GetUserTodos(user);

                return userTodos?.TodoItems
                    .OrderByDescending(item => item.CreatedAt)
                    .ToList() ?? new List<TodoItem>();
            }
        }

        public async Task<TodoItem> OpenTodoAsync(Guid guid, string user)
        {
            using (_context)
            {
                var userTodos = await GetUserTodos(user);

                var todo = userTodos?.OpenTodo(guid);

                await _context.SaveChangesAsync();

                return todo;
            }
        }

        private async Task<UserTodoItems> GetUserTodos(string user)
        {
            return await _context.UserTodoItems
                .Include(item => item.TodoItems)
                .FirstOrDefaultAsync(userItems => userItems.Username == user);
        }

    }
}