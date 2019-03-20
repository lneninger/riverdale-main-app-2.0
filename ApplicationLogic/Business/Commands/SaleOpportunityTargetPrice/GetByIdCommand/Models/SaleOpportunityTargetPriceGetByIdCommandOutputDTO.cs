using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand.Models
{
    public class SaleOpportunityTargetPriceGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public decimal? TargetPrice { get; set; }
        public int SaleSeasonTypeId { get; set; }

        public int SaleOpportunityId { get; set; }
        public IEnumerable<int> SampleBoxes { get; set; }
        public IEnumerable<int> SaleOpportunityTargetPriceProducts { get; set; }
    }
}
