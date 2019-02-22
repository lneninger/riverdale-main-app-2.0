using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand.Models
{
    public class SaleOpportunityPriceLevelProductUpdateCommandInputDTO
    {
        public int Id { get; set; }

        //public int SaleOpportunityId { get; set; }

        public int SaleProductId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductColorTypeId { get; set; }
        public int Order { get; internal set; }
    }
}