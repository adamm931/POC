using POC.Common.Service;

namespace POC.Logging.Service.Models.Log
{
    public class AddLogEntryServiceRequest : IServiceRequest
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Level { get; set; }
    }
}