using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Service.Contracts
{
    public interface ITodoManager
    {
        Task<TodoItem> AddTodoAsync(string name, string user);

        Task<TodoItem> CompleteTodoAsync(Guid guid, string user);

        Task<TodoItem> OpenTodoAsync(Guid guid, string user);

        Task DeleteTodoAsync(Guid guid, string user);

        Task<List<TodoItem>> ListTodosAsync(string user);

        Task AddUserAsync(string user);

        Task UpdateUserAsync(string user, string newUser);
    }
}
