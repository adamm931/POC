using POC.Common.Service;
using POC.Common.Service.Factory;
using POC.Todos.Service.Contracts;
using POC.Todos.Service.UseCases.AddTodo;
using POC.Todos.Service.UseCases.CompleteTodo;
using POC.Todos.Service.UseCases.DeleteTodo;
using POC.Todos.Service.UseCases.ListTodos;
using POC.Todos.Service.UseCases.OpenTodo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Todos.Service
{
    public class TodoService : ITodoService
    {
        private readonly IServiceMediator _serviceMediator = ServiceMediatorFactory.CreateMediator();

        public async Task<ServiceResponse<AddTodoServiceResponse>> AddAsync(AddTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle<AddTodoServiceRequest, AddTodoServiceResponse>(serviceRequest);

        public async Task<ServiceResponse> CompleteAsync(CompleteTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> OpenAsync(OpenTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> DeleteAsync(DeleteTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse<IEnumerable<ListTodosItemServiceResponse>>> ListAsync(ListTodosServiceRequest serviceRequest)
            => await _serviceMediator.Handle<ListTodosServiceRequest, IEnumerable<ListTodosItemServiceResponse>>(serviceRequest);
    }
}
