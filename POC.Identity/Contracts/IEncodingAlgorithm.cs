namespace POC.Identity.Contracts
{
    public interface IEncodingAlgorithm
    {
        string Encode(string input);

        string Decode(string input);
    }
}
