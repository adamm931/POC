using System.ComponentModel.DataAnnotations;

namespace POC.Models
{
    public class AddTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}