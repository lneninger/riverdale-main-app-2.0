using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models
{
    public class ProductCategoryGetByIdCommandOutputAllowedSizeItemDTO
    {
        public int Id { get; set; }
        public string Size { get; internal set; }
    }
}
