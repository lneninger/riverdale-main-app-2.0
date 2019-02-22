using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models
{
    public class SaleOpportunityPriceLevelInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public decimal? TargetPrice { get; set; }
        public int SaleSeasonTypeId { get; set; }

        public IEnumerable<int> SampleBoxes { get; set; }
        public int SaleOpportunityId { get; internal set; }
        public IEnumerable<int> SaleOpportunityPriceLevelProducts { get; set; }
    }
}