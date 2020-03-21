using POC.Common.Service;
using POC.Todos.Service.UseCases.AddTodo;
using POC.Todos.Service.UseCases.AddUser;
using POC.Todos.Service.UseCases.CompleteTodo;
using POC.Todos.Service.UseCases.DeleteTodo;
using POC.Todos.Service.UseCases.ListTodos;
using POC.Todos.Service.UseCases.OpenTodo;
using POC.Todos.Service.UseCases.UpdateUser;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Todos.Service.Contracts
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        Task<ServiceResponse<AddTodoServiceResponse>> AddAsync(AddTodoServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> CompleteAsync(CompleteTodoServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> OpenAsync(OpenTodoServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> DeleteAsync(DeleteTodoServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse<IEnumerable<ListTodosItemServiceResponse>>> ListAsync(ListTodosServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> AddUserAsync(AddUserServiceRequest serviceRequest);

        [OperationContract]
        Task<ServiceResponse> UpdateUserAsync(UpdateUserServiceRequest serviceRequest);
    }
}
