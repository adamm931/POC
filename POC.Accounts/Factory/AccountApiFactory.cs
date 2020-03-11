using POC.Accounts.Contracts;
using POC.Accounts.Internal;

namespace POC.Accounts.Factory
{
    public class AccountApiFactory
    {
        public static IAccountApi GetAccountApi() => new AccountApi();
    }
}
