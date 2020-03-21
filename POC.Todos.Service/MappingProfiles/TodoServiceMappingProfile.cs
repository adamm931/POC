using AutoMapper;
using POC.Todos.Domain;
using POC.Todos.Service.UseCases.AddTodo;
using POC.Todos.Service.UseCases.ListTodos;

namespace POC.Todos.Service.MappingProfiles
{
    public class TodoServiceMappingProfile : Profile
    {
        public TodoServiceMappingProfile()
        {
            CreateMap<TodoItem, ListTodosItemServiceResponse>();
            CreateMap<TodoItem, AddTodoServiceResponse>();
        }
    }
}