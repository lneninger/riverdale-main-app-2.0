using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models
{
    public class ProductCategoryAllowedSizeGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductCategoryAllowedSizeId { get; set; }
    }
}
