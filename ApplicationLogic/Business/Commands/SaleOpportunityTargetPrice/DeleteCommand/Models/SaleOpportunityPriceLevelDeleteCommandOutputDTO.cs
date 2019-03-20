using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand.Models
{
    public class SaleOpportunityTargetPriceDeleteCommandOutputDTO
    {

        public SaleOpportunityTargetPriceDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int SaleSeasonTypeId { get; set; }

        public decimal? TargetPrice { get; set; }
    }
}