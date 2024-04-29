using System;

namespace protopkuis1
{
    public class User
    {
        public string Username { get; }
        private string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Authenticate(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
