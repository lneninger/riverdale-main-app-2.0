using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand.Models
{
    public class SaleOpportunityProductDeleteCommandOutputDTO
    {

        public SaleOpportunityProductDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}