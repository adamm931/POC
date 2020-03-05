using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class AddTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}