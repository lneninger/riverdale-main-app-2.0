using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models
{
    public class SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityTargetPriceId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

    }
}