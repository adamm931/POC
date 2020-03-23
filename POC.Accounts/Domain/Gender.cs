using System;
using System.Collections.Generic;

namespace POC.Accounts.Domain
{
    public class Gender
    {

        public const string MaleName = "Male";

        public const string FemaleName = "Female";

        public const string UndefinedName = "Undefined";

        public static string[] AllNames => new[] { MaleName, FemaleName, UndefinedName };


        public static Gender Male = new Gender(MaleName);

        public static Gender Female = new Gender(FemaleName);

        public static Gender Undefined = new Gender(UndefinedName);

        public Gender(string value)
        {
            if (!IsValidGender(value))
            {
                throw new ArgumentException($"Gender: {value} is invalid");
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

        public static bool IsValidGender(string value)
        {
            return value == MaleName || value == FemaleName || value == UndefinedName;
        }
    }
}
