using POC.Identity.Contracts;
using POC.Identity.Internal;

namespace POC.Identity
{
    public class IdentityConfig
    {
        public static IEncoder EncoderProvider;

        public static IEncryption EncryptionProvider;

        public static void UseBase64Encryption()
        {
            EncoderProvider = Encoder.Base64;
        }

        public static void UseSha256ManagedHashing()
        {
            EncryptionProvider = Encryption.Sha256;
        }
    }
}
