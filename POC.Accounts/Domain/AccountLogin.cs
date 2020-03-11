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
            var login = new AccountLogin(username);

            login.SetAccount(Account.Empty());

            return login;
        }

        public void SetAccount(Account account)
        {
            Account = account;
        }

        public void UpdateUsername(string username)
        {
            Username = username;
        }
    }
}
