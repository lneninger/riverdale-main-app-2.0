using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models
{
    public class SampleBoxInsertCommandInputDTO
    {
        public int SaleOpportunityId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }
    }
}