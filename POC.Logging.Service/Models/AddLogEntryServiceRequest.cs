namespace POC.Logging.Service.Models
{
    public class AddLogEntryServiceRequest
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Level { get; set; }
    }
}