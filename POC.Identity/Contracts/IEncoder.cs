namespace POC.Identity.Contracts
{
    public interface IEncoder
    {
        string Encode(string input);

        string Decode(string input);
    }
}
