using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models
{
    public class SaleOpportunityPriceLevelProductInsertCommandInputDTO
    {
        public string Name { get; set; }

        public int SaleOpportunityPriceLevelId { get; set; }
        
        public int SaleOpportunityPriceLevelProductId { get; set; }

        public string ProductColorTypeId { get; set; }

    }
}