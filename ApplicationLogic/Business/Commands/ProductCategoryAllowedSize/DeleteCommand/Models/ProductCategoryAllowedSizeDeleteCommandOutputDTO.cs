using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand.Models
{
    public class ProductCategoryAllowedSizeDeleteCommandOutputDTO
    {

        public ProductCategoryAllowedSizeDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
    }
}