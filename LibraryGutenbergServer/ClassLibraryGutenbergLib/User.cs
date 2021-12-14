using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGutenbergLib
{
    [Serializable]
    public class User
    {
        private string login;
        private string password;
        private string username;
        private string action;

        public User() { }

        public string Login
        {
            get { return login; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    login = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        public string Password
        {
            get { return password; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    password = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

    }
}
