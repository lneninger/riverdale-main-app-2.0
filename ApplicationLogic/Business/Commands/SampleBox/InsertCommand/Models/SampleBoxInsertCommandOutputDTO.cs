using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models
{
    public class SampleBoxInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public int SaleOpportunityId { get; set; }
    }
}