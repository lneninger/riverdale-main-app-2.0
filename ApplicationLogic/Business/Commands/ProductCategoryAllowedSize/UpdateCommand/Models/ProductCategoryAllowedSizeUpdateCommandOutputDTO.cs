using System;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models
{
    public class ProductCategoryAllowedSizeUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Size { get; set; }
    }
}