using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public User(string userName,string password,string role,string fullName)
        {
            UserName = userName;
            Password = password;
            Role = role;
            FullName = fullName;
                
        }
    }
}
