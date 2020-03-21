using System;

namespace POC.Identity.Exceptions
{
    public class UsernameNotAvailableException : Exception
    {
        public UsernameNotAvailableException(string message) : base(message)
        {
        }
    }
}
