using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand.Models
{
    public class SaleOpportunityUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SaleSeasonTypeId { get; set; }
    }
}