using System;
using System.Collections.Generic;

namespace POC.Todos.Service.UseCases.ListTodos
{
    public class ListTodosServiceResponse
    {
        public List<Item> Items { get; set; }

        public class Item
        {
            public Guid Id { get; set; }

            public string Title { get; set; }

            public bool IsCompleted { get; set; }

            public DateTime CreatedAt { get; set; }

        }
    }
}