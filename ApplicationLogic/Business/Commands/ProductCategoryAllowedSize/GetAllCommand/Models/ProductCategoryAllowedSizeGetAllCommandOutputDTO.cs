using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand.Models
{
    public class ProductCategoryAllowedSizeGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}