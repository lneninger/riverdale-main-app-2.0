using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models
{
    public class GrowerGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GrowerGetByIdCommandOutputThirdPartySettingsDTO> ThirdPartySettings { get; set; }
        public GrowerGetByIdCommandOutputFreightoutDTO Freightout { get; set; }
    }
}