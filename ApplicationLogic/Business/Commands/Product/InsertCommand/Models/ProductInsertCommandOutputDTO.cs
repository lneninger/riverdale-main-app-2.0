using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Product.InsertCommand.Models
{
    public class ProductInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int Stems { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }
    }
}