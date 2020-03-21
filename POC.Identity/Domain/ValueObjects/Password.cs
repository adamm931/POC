namespace POC.Identity.Domain.ValueObjects
{
    public class Password
    {
        public string Hash { get; private set; }

        public string Salt { get; private set; }

        private Password(string plainValue)
            : this(plainValue, IdentityConfig.EncryptionProvider.GenerateSalt())
        {
        }

        private Password(string plainValue, string salt)
        {
            var hash = IdentityConfig.EncryptionProvider.HashPassword(plainValue, salt);

            Salt = IdentityConfig.EncoderProvider.Encode(salt);
            Hash = IdentityConfig.EncoderProvider.Encode(hash);
        }

        private Password() { }

        public bool Match(string plainValue)
        {
            var salt = IdentityConfig.EncoderProvider.Decode(Salt);

            return this == new Password(plainValue, salt);
        }

        public static implicit operator Password(string plainValue)
        {
            return new Password(plainValue);
        }

        public static bool operator ==(Password left, Password right)
        {
            return left?.Hash == right?.Hash;
        }

        public static bool operator !=(Password left, Password right)
        {
            return !(left == right);
        }
    }
}
