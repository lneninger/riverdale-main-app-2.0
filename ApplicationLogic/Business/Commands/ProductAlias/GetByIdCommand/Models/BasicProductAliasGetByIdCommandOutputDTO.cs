using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand.Models
{
    public class BasicProductAliasGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductAliasGetByIdCommandOutputThirdPartySettingsDTO> ThirdPartySettings { get; set; }
        public BasicProductAliasGetByIdCommandOutputFreightoutDTO Freightout { get; set; }
    }
}