namespace POC.Identity.Models
{
    public class UpdateUserLoginRequest
    {
        public string Username { get; set; }

        public string NewUsername { get; set; }

        public string NewPassword { get; set; }
    }
}
