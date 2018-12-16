using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.GetByIdCommand.Models
{
    public class FileGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FileGetByIdCommandOutputThirdPartySettingsDTO> ThirdPartySettings { get; set; }
        public FileGetByIdCommandOutputFreightoutDTO Freightout { get; set; }
    }
}