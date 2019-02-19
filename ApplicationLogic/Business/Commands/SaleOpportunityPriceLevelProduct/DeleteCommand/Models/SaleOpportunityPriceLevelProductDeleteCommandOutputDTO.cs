using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand.Models
{
    public class SaleOpportunityPriceLevelProductDeleteCommandOutputDTO
    {

        public SaleOpportunityPriceLevelProductDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}