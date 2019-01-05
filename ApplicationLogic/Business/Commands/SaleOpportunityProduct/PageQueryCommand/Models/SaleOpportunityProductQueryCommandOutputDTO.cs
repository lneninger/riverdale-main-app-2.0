using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand.Models
{
    public class SaleOpportunityProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

    }
}