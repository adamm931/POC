using POC.Service.Contracts;
using POC.Service.Managers;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoManager TodosManager = TodoManagerFactory.GetManager();

        public async Task<TodoItem> AddAsync(string name, string user)
        {
            return await TodosManager.AddTodoAsync(name, user);
        }

        public async Task AddUserAsync(string user)
        {
            await TodosManager.AddUser(user);
        }

        public async Task<TodoItem> CompleteAsync(Guid guid, string user)
        {
            return await TodosManager.CompleteTodoAsync(guid, user);
        }

        public async Task DeleteAsync(Guid guid, string user)
        {
            await TodosManager.DeleteTodoAsync(guid, user);
        }

        public async Task<List<TodoItem>> ListAsync(string user)
        {
            return await TodosManager.ListTodosAsync(user);
        }

        public async Task<TodoItem> OpenAsync(Guid guid, string user)
        {
            return await TodosManager.OpenTodoAsync(guid, user);

        }
    }
}
