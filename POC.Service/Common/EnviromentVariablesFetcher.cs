using System;
using System.Collections.Generic;

namespace POC.Service.Common
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
    }
}