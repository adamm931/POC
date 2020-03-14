using POC.Common;
using POC.Identity.Contracts;
using System.Security.Cryptography;

namespace POC.Identity.Services
{
    public class SHA256ManagedHasher : IHasher
    {
        public string Hash(string input)
        {
            var algorithm = new SHA256Managed();
            var hashedBytes = algorithm.ComputeHash(input.AsBytes());

            return hashedBytes.AsString();
        }
    }
}
