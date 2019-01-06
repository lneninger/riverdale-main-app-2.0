using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputSettingsDTO
    {
        public int Id { get; set; }

        public bool Delivered { get; set; }
    }
}
