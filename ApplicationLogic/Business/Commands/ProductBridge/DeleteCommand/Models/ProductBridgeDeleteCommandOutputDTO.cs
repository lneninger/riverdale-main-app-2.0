using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand.Models
{
    public class ProductBridgeDeleteCommandOutputDTO
    {

        public ProductBridgeDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public string ColorTypeId { get; set; }

        public int? RelatedProductSizeId { get; set; }

        public int Stems { get; set; }
        
    }
}