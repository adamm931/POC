using System;
using System.Runtime.Serialization;

namespace POC.Service.Models
{
    [DataContract]
    public class TodoItem
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]

        public string Title { get; set; }

        [DataMember]

        public bool IsCompleted { get; set; }

        [DataMember]

        public DateTime CreatedAt { get; set; }

        public Guid UserTodoItemsId { get; set; }

        public UserTodoItems UserTodoItems { get; set; }

        private TodoItem()
        {
        }

        public TodoItem(string title)
        {
            Id = Guid.NewGuid();
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