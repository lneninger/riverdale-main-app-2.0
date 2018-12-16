using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.File.GetByIdCommand.Models
{
    public class FileGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyFileId { get; set; }
    }
}
