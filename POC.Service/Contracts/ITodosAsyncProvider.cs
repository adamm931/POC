using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Service.Contracts
{
    public interface ITodosAsyncProvider
    {
        Task<TodoItem> AddTodoAsync(string name);

        Task<TodoItem> CompleteTodoAsync(Guid guid);

        Task<TodoItem> OpenTodoAsync(Guid guid);

        Task DeleteTodoAsync(Guid guid);

        Task<List<TodoItem>> ListTodosAsync();
    }
}
