using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models
{
    public class SaleOpportunityPriceLevelProductInsertCommandInputDTO
    {
        public string Name { get; set; }

        public int SampleBoxId { get; set; }

        public int SaleOpportunityProductId { get; set; }
        
    }
}