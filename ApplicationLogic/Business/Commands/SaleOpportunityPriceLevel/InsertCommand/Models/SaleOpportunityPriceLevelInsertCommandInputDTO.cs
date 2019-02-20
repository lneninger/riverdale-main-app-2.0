using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models
{
    public class SaleOpportunityPriceLevelInsertCommandInputDTO
    {
        public int SaleSeasonTypeId { get; set; }

        public decimal TargetPrice { get; set; }

        public string Name { get; set; }
    }
}