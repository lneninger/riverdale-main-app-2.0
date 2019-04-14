using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models
{
    public class ProductCategoryAllowedSizeInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Size { get; set; }
    }
}