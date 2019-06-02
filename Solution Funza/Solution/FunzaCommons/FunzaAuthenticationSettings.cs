using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaCommons
{
    public class FunzaAuthenticationSettings
    {
        public string AuthenticationURL { get; set; }

        public string AuthenticationUserName { get; set; }

        public string AuthenticationPassword { get; set; }

        public FunzaTokenSettings TokenSettings { get; set; }

    }
}
