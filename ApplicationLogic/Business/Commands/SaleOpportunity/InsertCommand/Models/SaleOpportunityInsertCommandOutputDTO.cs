using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models
{
    public class SaleOpportunityInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}