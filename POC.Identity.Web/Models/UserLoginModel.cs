namespace POC.Identity.Web.Models
{
    public class UserLoginModel : BaseModel
    {
        public static UserLoginModel Empty = new UserLoginModel();

        public string Username { get; set; }

        public string Password { get; set; }
    }
}