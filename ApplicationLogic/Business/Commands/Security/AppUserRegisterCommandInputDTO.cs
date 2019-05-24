using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.Security
{
    public class AppUserRegisterCommandInputDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string Password { get; set; }
    }
}
