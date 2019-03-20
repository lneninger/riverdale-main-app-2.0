using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models
{
    public class SaleOpportunityTargetPricePageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SaleSeasonTypeId { get; set; }

        public decimal? TargetPrice { get; set; }
    }
}