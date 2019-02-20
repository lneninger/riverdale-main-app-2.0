using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.DeleteCommand.Models
{
    public class SaleOpportunityPriceLevelDeleteCommandOutputDTO
    {

        public SaleOpportunityPriceLevelDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}