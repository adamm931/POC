using POC.Common.Domain;
using System;

namespace POC.Logging.Domain
{
    public class LogEntry : Entity
    {
        public LogEntry(string title, string text, LogEntryLevel level)
        {
            Title = title;
            Text = text;
            Level = level;

            CreatedAt = DateTime.UtcNow;
        }

        public string Text { get; private set; }

        public string Title { get; private set; }

        public LogEntryLevel Level { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
