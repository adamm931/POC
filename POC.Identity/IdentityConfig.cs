using POC.Identity.Contracts;
using POC.Identity.Internal;

namespace POC.Identity
{
    public class IdentityConfig
    {
        public static IEncoder EncoderProvider = Encoder.Base64;

        public static IEncryption EncryptionProvider = Encryption.Sha256;
    }
}
