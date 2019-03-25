using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models
{
    public class SaleOpportunityTargetPriceInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? TargetPrice { get; set; }

        public int SaleSeasonTypeId { get; set; }

        public string SeasonName { get; set; }

        public int AlternativesAmount { get; set; }

        public int SaleOpportunityId { get; set; }

    }
}