using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.Product.Commons;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand.Models
{
    public class ProductBridgeGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int Stems { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
