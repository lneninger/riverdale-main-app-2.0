using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand.Models
{
    public class SaleOpportunityProductInsertCommandInputDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }
    }
}