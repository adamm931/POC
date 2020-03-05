using System.Collections.Generic;

namespace POC.Web.Models
{
    public class TodoListViewModel
    {
        public IEnumerable<TodoListItemViewModel> Items { get; set; }
    }
}