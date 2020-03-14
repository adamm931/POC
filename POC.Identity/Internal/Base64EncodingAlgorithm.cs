using POC.Common;
using POC.Identity.Contracts;

namespace POC.Identity.Internal
{
    public class Base64EncodingAlgorithm : IEncodingAlgorithm
    {
        public string Decode(string input)
        {
            return input.FromBase64String();
        }

        public string Encode(string input)
        {
            return input.ToBase64String();
        }
    }
}
