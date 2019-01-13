using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models
{
    public class ProductAllowedColorTypeGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductAllowedColorTypeId { get; set; }
    }
}
