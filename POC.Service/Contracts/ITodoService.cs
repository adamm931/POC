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
        [OperationContract(Action = "Add", ReplyAction = "Add")]
        TodoItem Add(string name);

        [OperationContract(Action = "Complete", ReplyAction = "Complete")]
        TodoItem Complete(Guid guid);

        [OperationContract(Action = "Open", ReplyAction = "Open")]
        TodoItem Open(Guid guid);

        [OperationContract(Action = "Delete", ReplyAction = "Delete")]
        void Delete(Guid guid);

        [OperationContract(Action = "List", ReplyAction = "List")]
        List<TodoItem> List();
    }

    [ServiceContract]
    public interface ITodoServiceAsync// : ITodoService
    {
        [OperationContract(Action = "Add", ReplyAction = "Add")]
        Task<TodoItem> AddAsync(string name);

        [OperationContract(Action = "Complete", ReplyAction = "Complete")]
        Task<TodoItem> CompleteAsync(Guid guid);

        [OperationContract(Action = "Open", ReplyAction = "Open")]
        Task<TodoItem> OpenAsync(Guid guid);

        [OperationContract(Action = "Delete", ReplyAction = "Delete")]
        Task DeleteAsync(Guid guid);

        [OperationContract(Action = "List", ReplyAction = "List")]
        Task<List<TodoItem>> ListAsync();
    }
}
