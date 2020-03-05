using POC.Service.Contracts;
using POC.Service.Data;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodosProvider TodosAsyncProvider = TodosProviderResolver.GetAsyncProvider();

        public async Task<TodoItem> AddAsync(string name, string user)
        {
            return await TodosAsyncProvider.AddTodoAsync(name, user);
        }

        public async Task<TodoItem> CompleteAsync(Guid guid, string user)
        {
            return await TodosAsyncProvider.CompleteTodoAsync(guid, user);
        }

        public async Task DeleteAsync(Guid guid, string user)
        {
            await TodosAsyncProvider.DeleteTodoAsync(guid, user);
        }

        public async Task<List<TodoItem>> ListAsync(string user)
        {
            return await TodosAsyncProvider.ListTodosAsync(user);
        }

        public async Task<TodoItem> OpenAsync(Guid guid, string user)
        {
            return await TodosAsyncProvider.OpenTodoAsync(guid, user);

        }
    }
}
