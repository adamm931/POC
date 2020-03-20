using POC.Common.Domain;

namespace POC.Accounts.Domain
{
    public class AccountLogin : Entity
    {
        public string Username { get; private set; }

        public Account Account { get; private set; }

        internal AccountLogin(string username)
        {
            Username = username;
        }

        private AccountLogin() { }

        public static AccountLogin CreateAndInitializeAccount(string username)
        {
            return new AccountLogin(username)
            {
                Account = Account.Empty()
            };
        }

        public void UpdateUsername(string username)
        {
            Username = username;
        }
    }
}
