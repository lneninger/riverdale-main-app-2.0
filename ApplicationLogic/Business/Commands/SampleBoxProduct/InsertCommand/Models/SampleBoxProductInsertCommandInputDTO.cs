using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand.Models
{
    public class SampleBoxProductInsertCommandInputDTO
    {
        public string Name { get; set; }

        public int SampleBoxId { get; set; }

        public int SaleOpportunityTargetPriceProductId { get; set; }
        
    }
}