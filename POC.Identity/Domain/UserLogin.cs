using POC.Common;
using System;
using System.Security.Cryptography;
using System.Text;

namespace POC.Identity.Domain
{
    public class UserLogin
    {
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public string PasswordSalt { get; private set; }

        // TODO: remote hard coded
        private static HashAlgorithm HashAlgorithm => new SHA256Managed();

        private UserLogin(string username, string passwordHash, string passwordSalt)
        {
            Id = Guid.NewGuid();

            Username = username;
            PasswordHash = passwordHash.ToBase64String();
            PasswordSalt = passwordSalt.ToBase64String();
        }

        private UserLogin() { }

        public static UserLogin Create(string username, string password)
        {
            var salt = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var hashedPassword = GetPasswordHash(password, salt);

            return new UserLogin(username, hashedPassword, salt);
        }

        public bool Challenge(string username, string password)
        {
            var hash = PasswordHash.FromBase64String();
            var salt = PasswordSalt.FromBase64String();

            return Username == username && hash == GetPasswordHash(password, salt);
        }

        private static string GetPasswordHash(string password, string salt)
        {
            var passwordWithSalt = Encoding.ASCII.GetBytes($"{password}{salt}");
            var hashedPasswordBytes = HashAlgorithm.ComputeHash(passwordWithSalt);
            return Encoding.ASCII.GetString(hashedPasswordBytes);
        }
    }
}
