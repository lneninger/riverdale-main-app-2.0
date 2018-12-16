using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models
{
    public class ProductMediaGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductMediaId { get; set; }
    }
}
