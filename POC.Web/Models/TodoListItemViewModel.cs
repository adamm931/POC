using System;

namespace POC.Web.Models
{
    public class TodoListItemViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}