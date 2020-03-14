﻿using POC.Common.Domain;

namespace POC.Identity.Domain
{
    public class UserLogin : Entity
    {
        public Username Username { get; private set; }

        public Password Password { get; private set; }

        public UserLogin(Username username, Password password)
        {
            Username = username;
            Password = password;
        }

        private UserLogin() { }

        public void Update(Username username, Password password)
        {
            Username = username;
            Password = password;
        }

        public bool Challenge(string username, string password)
        {
            return Username == username && Password.Match(password);
        }
    }
}
