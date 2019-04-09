using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand.Models
{
    public class SaleOpportunityTargetPriceProductDeleteCommandOutputDTO
    {

        public SaleOpportunityTargetPriceProductDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int TargetPriceId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}