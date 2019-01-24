using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models
{
    public class GrowerGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyGrowerId { get; set; }
    }
}
