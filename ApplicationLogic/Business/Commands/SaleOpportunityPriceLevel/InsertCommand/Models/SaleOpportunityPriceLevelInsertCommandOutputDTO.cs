using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models
{
    public class SaleOpportunityPriceLevelInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public int SaleOpportunityPriceLevelId { get; set; }
    }
}