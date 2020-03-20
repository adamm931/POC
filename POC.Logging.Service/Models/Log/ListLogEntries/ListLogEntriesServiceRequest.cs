using POC.Common.Service;
using POC.Logging.Domain;
using System;

namespace POC.Logging.Service.Models.Log
{
    public class ListLogEntriesServiceRequest : IServiceRequest<ListLogEntriesServiceResponse>
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public LogEntryLevel Level { get; set; }

        public string Content { get; set; }
    }
}