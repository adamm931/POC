namespace POC.Identity.Web.Models
{
    public class BaseModel
    {
        public bool IsSuccess { get; set; } = true;

        public string FailMessage { get; set; }

        public void SetFailMessage(string message)
        {
            IsSuccess = false;
            FailMessage = message;
        }
    }
}