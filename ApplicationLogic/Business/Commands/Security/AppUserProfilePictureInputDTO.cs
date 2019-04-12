using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.Security
{
    public class AppUserProfilePictureInputDTO
    {
        public string UserId { get; set; }

        public string PictureUrl { get; set; }
    }
}
