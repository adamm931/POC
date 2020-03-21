using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static IEnumerable<TType> GetInstancesOf<TType>(this Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .Where(type => typeof(TType).IsAssignableFrom(type))
                .Select(profile => Activator.CreateInstance(profile))
                .Cast<TType>();
        }

        public static Type GetTypeOf<TType>(this Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .FirstOrDefault(type => typeof(TType).IsAssignableFrom(type));
        }

        public static IEnumerable<Type> GetTypesOf<TType>(this Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .Where(type => typeof(TType).IsAssignableFrom(type));
        }
    }
}
