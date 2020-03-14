using System;

namespace POC.Identity.Domain
{
    public class Username
    {
        public Username(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        private Username() { }

        public string Value { get; private set; }

        public static implicit operator Username(string value)
        {
            return new Username(value);
        }

        public static implicit operator string(Username username)
        {
            return username.Value;
        }

        public static bool operator ==(Username left, Username right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Username left, Username right)
        {
            return !(left.Value == right.Value);
        }
    }
}
