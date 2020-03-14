using POC.Identity.Contracts;
using POC.Identity.Services;
using System;

namespace POC.Identity.Internal
{
    public class Encryption : IEncryption
    {
        private readonly IHasher Hasher;

        public static IEncryption Sha256 = new Encryption(new SHA256ManagedHasher());

        private Encryption(IHasher hasher)
        {
            Hasher = hasher;
        }

        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public string HashPassword(string password, string salt)
        {
            return Hasher.Hash(password + salt);
        }
    }
}
