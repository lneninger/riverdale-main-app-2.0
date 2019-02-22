using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models
{
    public class SaleOpportunityPriceLevelPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SaleSeasonTypeId { get; set; }

        public decimal? TargetPrice { get; set; }
    }
}