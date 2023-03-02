using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Commands
{
    public class LoginCommand
    {
        public string Username { get; init; }
        public string Password { get; init; }

        public LoginCommand(string username, string password) 
        {
            Username = username; 
            Password = password; 
        }
    }
}
