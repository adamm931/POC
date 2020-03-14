using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Service.Contracts
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        Task<TodoItem> AddAsync(string name, string user);

        [OperationContract]
        Task<TodoItem> CompleteAsync(Guid guid, string user);

        [OperationContract]
        Task<TodoItem> OpenAsync(Guid guid, string user);

        [OperationContract]
        Task DeleteAsync(Guid guid, string user);

        [OperationContract]
        Task<List<TodoItem>> ListAsync(string user);

        [OperationContract]
        Task AddUserAsync(string user);

        [OperationContract]
        Task UpdateUserAsync(string user, string newUser);
    }
}
