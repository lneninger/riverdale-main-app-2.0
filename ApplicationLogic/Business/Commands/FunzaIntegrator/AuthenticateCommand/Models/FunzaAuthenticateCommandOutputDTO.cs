using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand.Models
{
    public class FunzaAuthenticateCommandOutputDTO
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string ExpiresIn { get; set; }
        public string UserId { get; internal set; }
        public string UserName { get; set; }
        public string Issued { get; set; }
        public string Expires { get; set; }
        public string EncryptedAccessToken { get; internal set; }
    }
}