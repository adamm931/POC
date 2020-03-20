using System;
using System.Linq;

namespace POC.Logging.Domain
{
    public class LogEntryLevel
    {
        public static LogEntryLevel Debug = new LogEntryLevel(nameof(Debug));

        public static LogEntryLevel Information = new LogEntryLevel(nameof(Information));

        public static LogEntryLevel Warning = new LogEntryLevel(nameof(Warning));

        public static LogEntryLevel Error = new LogEntryLevel(nameof(Error));

        public LogEntryLevel(string value)
        {
            var validValues = new[] { nameof(Debug), nameof(Information), nameof(Warning), nameof(Error) };

            if (!validValues.Any(v => v == value))
            {
                throw new ArgumentException($"Invalid value: {value} for {nameof(LogEntryLevel)}");
            }

            Value = value;
        }

        private LogEntryLevel() { }

        public string Value { get; }

        public static implicit operator LogEntryLevel(string value)
        {
            return new LogEntryLevel(value);
        }

        public static bool operator ==(LogEntryLevel left, LogEntryLevel right)
        {
            return left?.Value == right?.Value;
        }

        public static bool operator !=(LogEntryLevel left, LogEntryLevel right)
        {
            return !(left == right);
        }
    }
}
