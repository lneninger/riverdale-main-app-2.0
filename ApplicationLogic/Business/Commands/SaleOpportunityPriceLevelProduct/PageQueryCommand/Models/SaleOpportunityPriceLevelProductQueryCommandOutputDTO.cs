using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models
{
    public class SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityPriceLevelId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

    }
}