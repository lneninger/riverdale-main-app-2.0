﻿using System;

namespace ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models
{
    public class AppUserGetAllCommandOutputDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}