using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models
{
    public class AppUserRoleGetByIdCommandOutputDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}