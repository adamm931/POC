using System;

namespace POC.Todos.Service.UseCases.ListTodos
{
    public class ListTodosItemServiceResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}