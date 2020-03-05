using POC.Service.Contracts;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Service.Data
{
    public class InMemoryTodosProvider : ITodosProvider
    {
        private static readonly List<TodoItem> _todos = new List<TodoItem>
            {
                new TodoItem("Task 1"),
                new TodoItem("Task 2"),
                new TodoItem("Task 3"),
                new TodoItem("Task 4"),
                new TodoItem("Task 5"),
                new TodoItem("Task 6"),
            };

        public TodoItem AddTodo(string name)
        {
            var item = new TodoItem(name);

            _todos.Add(item);

            return item;
        }

        public Task<TodoItem> AddTodoAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> AddTodoAsync(string name, string user)
        {
            throw new NotImplementedException();
        }

        public TodoItem CompleteTodo(Guid guid)
        {
            var item = _todos.FirstOrDefault(todo => todo.Id == guid);

            item?.Complete();

            return item;
        }

        public async Task<TodoItem> CompleteTodoAsync(Guid guid)
        {
            return await Task.Run(() => CompleteTodo(guid));
        }

        public Task<TodoItem> CompleteTodoAsync(Guid guid, string user)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodo(Guid guid)
        {
            _todos.RemoveAll(todo => todo.Id == guid);
        }

        public async Task DeleteTodoAsync(Guid guid)
        {
            await Task.Run(() => DeleteTodo(guid));
        }

        public Task DeleteTodoAsync(Guid guid, string user)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> ListTodos()
        {
            return _todos;
        }

        public async Task<List<TodoItem>> ListTodosAsync()
        {
            return await Task.Run(() => ListTodos());
        }

        public Task<List<TodoItem>> ListTodosAsync(string user)
        {
            throw new NotImplementedException();
        }

        public TodoItem OpenTodo(Guid guid)
        {
            var item = _todos.FirstOrDefault(todo => todo.Id == guid);

            item?.Open();

            return item;
        }

        public async Task<TodoItem> OpenTodoAsync(Guid guid)
        {
            return await Task.Run(() => OpenTodo(guid));
        }

        public Task<TodoItem> OpenTodoAsync(Guid guid, string user)
        {
            throw new NotImplementedException();
        }
    }
}