using System;

namespace POC.Todos.Service.UseCases.AddTodo
{
    public class AddTodoServiceResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}