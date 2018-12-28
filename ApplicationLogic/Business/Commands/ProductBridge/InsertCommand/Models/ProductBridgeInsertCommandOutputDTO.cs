using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models
{
    public class ProductBridgeInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int Stems { get; set; }
    }
}