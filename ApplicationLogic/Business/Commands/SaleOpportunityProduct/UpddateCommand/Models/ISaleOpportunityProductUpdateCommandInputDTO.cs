using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand.Models
{
    public class SaleOpportunityProductUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}