namespace POC.Identity.Service.Models
{
    public class UpdateUserLoginServiceRequest
    {
        public string Username { get; set; }

        public string NewUsername { get; set; }

        public string NewPassword { get; set; }
    }
}