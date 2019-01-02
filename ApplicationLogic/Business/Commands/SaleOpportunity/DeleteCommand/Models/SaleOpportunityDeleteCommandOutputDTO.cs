using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.DeleteCommand.Models
{
    public class SaleOpportunityDeleteCommandOutputDTO
    {

        public SaleOpportunityDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}