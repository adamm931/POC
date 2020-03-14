using System;
using System.Collections.Generic;

namespace POC.Accounts.Domain
{
    public class Gender
    {
        public static Gender Male = new Gender(nameof(Male));

        public static Gender Female = new Gender(nameof(Female));

        public static Gender Undefined = new Gender("Undefined");

        private Gender(string value)
        {
            Value = value;
        }

        private Gender() { }

        public static Gender Parse(string value)
        {
            if (value != Male.Value && value != Female.Value)
            {
                throw new InvalidOperationException($"Gender value can only be '{Male.Value}' or '{Female.Value}'");
            }

            return new Gender(value);
        }

        public string Value { get; private set; }

        public static bool operator ==(Gender left, Gender right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Gender left, Gender right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return Value;
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
