using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models
{
    public class ProductBridgeUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public string ColorTypeId { get; set; }

        public int? RelatedProductSizeId { get; set; }

        public int RelatedProductAmount { get; set; }
    }
}