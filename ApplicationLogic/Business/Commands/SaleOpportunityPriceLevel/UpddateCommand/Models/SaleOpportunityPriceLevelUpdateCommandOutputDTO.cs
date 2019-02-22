using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand.Models
{
    public class SaleOpportunityPriceLevelUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; internal set; }
        public decimal? TargetPrice { get; set; }
        public int SaleSeasonTypeId { get; set; }
        public IEnumerable<int> SampleBoxes { get; set; }
        public int SaleOpportunityId { get; set; }
        public IEnumerable<int> SaleOpportunityPriceLevelProducts { get; set; }
    }
}