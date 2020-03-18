namespace POC.Logging.Domain
{
    public class LogEntryLevel
    {
        public static LogEntryLevel Debug = new LogEntryLevel(nameof(Debug));


        public static LogEntryLevel Information = new LogEntryLevel(nameof(Debug));


        public static LogEntryLevel Warning = new LogEntryLevel(nameof(Debug));


        public static LogEntryLevel Error = new LogEntryLevel(nameof(Debug));

        public LogEntryLevel(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static implicit operator LogEntryLevel(string value)
        {
            return new LogEntryLevel(value);
        }
    }
}
