using POC.Identity.Contracts;

namespace POC.Identity.Internal
{
    internal class Encoder : IEncoder
    {
        private readonly IEncodingAlgorithm Algorithm;

        internal static IEncoder Base64 = new Encoder(new Base64EncodingAlgorithm());

        private Encoder(IEncodingAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }

        public string Decode(string input)
        {
            return Algorithm.Decode(input);
        }

        public string Encode(string input)
        {
            return Algorithm.Encode(input);
        }
    }
}
