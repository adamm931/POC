using System;
using System.Collections.Generic;

namespace POC.Logging.Service.UseCases.ListLogEntries
{
    public class ListLogEntriesServiceResponse
    {
        public List<Item> Items { get; set; }

        public class Item
        {
            public string Title { get; set; }

            public string Text { get; set; }

            public string Level { get; set; }

            public DateTime CreatedAt { get; set; }
        }
    }
}