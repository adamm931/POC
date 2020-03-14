using System;
using System.Text;

namespace POC.Common
{
    public static class Extensions
    {
        public static string ToBase64String(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static string FromBase64String(this string input)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(input));
        }

        public static byte[] AsBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        public static string AsString(this byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
}
