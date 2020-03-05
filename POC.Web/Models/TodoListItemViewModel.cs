using System;

namespace POC.Web.Models
{
    public class TodoListItemViewModel
    {
        public Guid Id { get; set; }

        public int Index { get; set; }

        public string Title { get; set; }

        public bool IsComleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}