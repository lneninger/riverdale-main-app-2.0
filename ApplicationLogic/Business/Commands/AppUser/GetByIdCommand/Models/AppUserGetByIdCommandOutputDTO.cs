using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models
{
    public class AppUserGetByIdCommandOutputDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}