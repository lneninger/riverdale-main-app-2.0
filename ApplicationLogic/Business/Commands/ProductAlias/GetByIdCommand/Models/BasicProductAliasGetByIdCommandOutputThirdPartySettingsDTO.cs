using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand.Models
{
    public class ProductAliasGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductAliasId { get; set; }
    }
}
