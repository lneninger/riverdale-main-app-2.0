using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.InsertCommand.Models
{
    public class ProductCategoryInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
    }
}