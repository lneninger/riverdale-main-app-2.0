using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand.Models
{
    public class SaleOpportunityTargetPriceGetAllCommandOutputDTO
    {
        public int Id { get; set; }

        public decimal? TargetPrice { get; set; }
        public int SaleSeasonTypeId { get; set; }
        public int SaleOpportunityId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}