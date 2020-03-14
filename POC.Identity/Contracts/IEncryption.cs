namespace POC.Identity.Contracts
{
    public interface IEncryption
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
