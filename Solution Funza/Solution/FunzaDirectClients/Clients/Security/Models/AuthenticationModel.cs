using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.InternalClients.Security.Models
{
    public class AuthenticationModel
    {
        public string UserNameOrEmailAddress { get; set; }

        public string Password { get; set; }

        public bool RememberClient { get; set; }
    }
}
