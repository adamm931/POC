using POC.Common.Domain;
using System;

namespace POC.Todos.Domain
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UserTodoItemsId { get; set; }

        public UserTodoItems UserTodoItems { get; set; }

        private TodoItem()
        {
        }

        public TodoItem(string title)
        {
            Title = title;
            CreatedAt = DateTime.Now;
        }

        public void Complete()
        {
            IsCompleted = true;
        }

        public void Open()
        {
            IsCompleted = false;
        }
    }
}