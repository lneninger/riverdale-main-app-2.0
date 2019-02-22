using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand.Models
{
    public class SaleOpportunityPriceLevelGetAllCommandOutputDTO
    {
        public int Id { get; set; }

        public decimal? TargetPrice { get; set; }
        public int SaleSeasonTypeId { get; set; }
        public int SaleOpportunityId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}