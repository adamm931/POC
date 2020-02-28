using System.Collections.Generic;

namespace POC.Models
{
    public class TodoListViewModel
    {
        public IEnumerable<TodoListItemViewModel> Items { get; set; }
    }
}