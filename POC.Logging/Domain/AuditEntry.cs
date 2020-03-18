using POC.Common.Domain;
using System;

namespace POC.Logging.Domain
{
    public class AuditEntry : Entity
    {
        public AuditEntry(string title, string text)
        {
            CreatedAt = DateTime.UtcNow;
            Title = title;
            Text = text;
        }

        private AuditEntry() { }

        public DateTime CreatedAt { get; private set; }

        public string Title { get; }
        public string Text { get; }
    }
}
