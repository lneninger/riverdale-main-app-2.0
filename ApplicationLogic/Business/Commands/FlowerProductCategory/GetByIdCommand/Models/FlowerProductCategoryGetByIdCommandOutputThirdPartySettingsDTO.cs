using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models
{
    public class FlowerProductCategoryGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyFlowerProductCategoryId { get; set; }
    }
}
