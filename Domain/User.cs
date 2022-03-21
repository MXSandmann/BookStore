using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class User : Entity
    {
        public User(string userName, string password, string email, Role role)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
        }
        private User()
        {

        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }  
        public Role Role { get; private set; }   
    }
}
