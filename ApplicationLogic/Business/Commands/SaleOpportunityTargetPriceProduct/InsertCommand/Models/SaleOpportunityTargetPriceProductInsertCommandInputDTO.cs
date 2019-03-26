using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand.Models
{
    public class SaleOpportunityTargetPriceProductInsertCommandInputDTO
    {
        public string Name { get; set; }

        public int TargetPriceId { get; set; }
        
        public int ProductId { get; set; }

        public string ProductColorTypeId { get; set; }

    }
}