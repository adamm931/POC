using System;
using System.Collections.Generic;

namespace POC.Common.Enviroment
{
    public class EnviromentVariablesFetcher
    {
        public static string GetVaraiable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);

            if (string.IsNullOrEmpty(value))
            {
                throw new KeyNotFoundException($"Key: {name} is not fount in enviroment variables");
            }

            return value;
        }

        public static TValue GetVaraiable<TValue>(string name)
        {
            var value = GetVaraiable(name);

            object obj = value;

            if (typeof(TValue) == typeof(int))
            {
                obj = int.Parse(value);
            }

            return (TValue)Convert.ChangeType(obj, typeof(TValue));
        }
    }
}