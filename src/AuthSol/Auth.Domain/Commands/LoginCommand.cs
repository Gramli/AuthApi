using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Commands
{
    public class LoginCommand
    {
        public string UserName { get; init; }
        public string Password { get; init; }

        public LoginCommand(string username, string password) 
        {  
            UserName = username; 
            Password = password; 
        }
    }
}
