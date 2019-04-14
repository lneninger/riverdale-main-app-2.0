using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models
{
    public class ProductCategoryAllowedSizePageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string ProductCategoryName { get; set; }
        public string Size { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}