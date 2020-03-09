namespace POC.Web.Authentication.Contracts
{
    public interface IUser
    {
        string Username { get; }
    }

    public static class IUserExtensions
    {
        public static bool IsResolved(this IUser user) => !string.IsNullOrEmpty(user.Username);
    }
}
