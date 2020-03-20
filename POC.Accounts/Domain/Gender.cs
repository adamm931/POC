using System;
using System.Collections.Generic;

namespace POC.Accounts.Domain
{
    public class Gender
    {
        public static Gender Male = new Gender(nameof(Male));

        public static Gender Female = new Gender(nameof(Female));

        public static Gender Undefined = new Gender(nameof(Undefined));

        public Gender(string value)
        {
            if (value != nameof(Male) && value != nameof(Female) && value != nameof(Undefined))
            {
                throw new ArgumentException($"Gender value is invalid");
            }

            Value = value;
        }

        private Gender() { }

        public string Value { get; private set; }

        public static bool operator ==(Gender left, Gender right)
        {
            return left?.Value == right?.Value;
        }

        public static bool operator !=(Gender left, Gender right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator Gender(string value)
        {
            return new Gender(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Gender gender &&
                   Value == gender.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
