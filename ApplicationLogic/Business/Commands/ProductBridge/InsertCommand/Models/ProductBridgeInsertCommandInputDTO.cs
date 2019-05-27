using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models
{
    public class ProductBridgeInsertCommandInputDTO
    {
        public int Id { get; set; }

        public string ColorTypeId { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int RelatedProductAmount { get; set; }

        public int RelatedProductSizeId { get; set; }
    }
}