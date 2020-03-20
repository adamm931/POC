﻿using POC.Common.Service;
using POC.Configuration.DI;
using POC.Todos.Service.Contracts;
using POC.Todos.Service.UseCases.AddTodo;
using POC.Todos.Service.UseCases.AddUser;
using POC.Todos.Service.UseCases.CompleteTodo;
using POC.Todos.Service.UseCases.DeleteTodo;
using POC.Todos.Service.UseCases.ListTodos;
using POC.Todos.Service.UseCases.OpenTodo;
using POC.Todos.Service.UseCases.UpdateUser;
using System.Threading.Tasks;

namespace POC.Todos.Service
{
    public class TodoService : ITodoService
    {
        private readonly IServiceMediator _serviceMediator;

        public TodoService() : this(new ServiceMediator(Container<TodoService>.Instance))
        {
        }

        private TodoService(IServiceMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        public async Task<ServiceResponse<AddTodoServiceResponse>> AddAsync(AddTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle<AddTodoServiceRequest, AddTodoServiceResponse>(serviceRequest);

        public async Task<ServiceResponse> CompleteAsync(CompleteTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> OpenAsync(OpenTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> DeleteAsync(DeleteTodoServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse<ListTodosServiceResponse>> ListAsync(ListTodosServiceRequest serviceRequest)
            => await _serviceMediator.Handle<ListTodosServiceRequest, ListTodosServiceResponse>(serviceRequest);

        public async Task<ServiceResponse> AddUserAsync(AddUserServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);

        public async Task<ServiceResponse> UpdateUserAsync(UpdateUserServiceRequest serviceRequest)
            => await _serviceMediator.Handle(serviceRequest);
    }
}
