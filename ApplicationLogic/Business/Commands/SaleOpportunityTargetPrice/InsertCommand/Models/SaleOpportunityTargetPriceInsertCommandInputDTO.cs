using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models
{
    public class SaleOpportunityTargetPriceInsertCommandInputDTO
    {
        public int SaleOpportunityId { get; set; }

        public int SaleSeasonTypeId { get; set; }

        public decimal TargetPrice { get; set; }

        public string Name { get; set; }

        public int AlterenativesAmount { get; set; }
    }
}