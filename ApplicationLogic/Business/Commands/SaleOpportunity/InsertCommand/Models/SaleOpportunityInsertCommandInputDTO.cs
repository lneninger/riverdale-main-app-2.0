using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models
{
    public class SaleOpportunityInsertCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SaleOpportunityTypeId { get; set; }
    }
}