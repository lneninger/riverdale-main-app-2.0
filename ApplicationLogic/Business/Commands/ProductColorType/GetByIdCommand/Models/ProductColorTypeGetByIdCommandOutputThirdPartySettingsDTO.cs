using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models
{
    public class ProductColorTypeGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyAppProductColorTypeId { get; set; }
    }
}
