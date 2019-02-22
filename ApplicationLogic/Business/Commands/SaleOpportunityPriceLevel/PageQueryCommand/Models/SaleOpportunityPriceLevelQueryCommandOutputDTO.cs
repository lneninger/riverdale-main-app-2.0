using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models
{
    public class SaleOpportunityPriceLevelPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}