using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand.Models
{
    public class ProductCategoryDeleteCommandOutputDTO
    {

        public ProductCategoryDeleteCommandOutputDTO()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}