using POC.Web.Validation.Attributes;

namespace POC.Web.Models
{
    public class AddTodoViewModel
    {
        [PocRequired(nameof(Title))]
        public string Title { get; set; }
    }
}