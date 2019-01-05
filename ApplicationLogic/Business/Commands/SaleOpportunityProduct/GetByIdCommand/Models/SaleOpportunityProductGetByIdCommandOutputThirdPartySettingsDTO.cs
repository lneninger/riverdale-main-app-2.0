using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand.Models
{
    public class SaleOpportunityProductGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductId { get; set; }
    }
}
