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

        public int SaleSeasonTypeId { get; set; }

        public decimal? TargetPrice { get; set; }
    }
}