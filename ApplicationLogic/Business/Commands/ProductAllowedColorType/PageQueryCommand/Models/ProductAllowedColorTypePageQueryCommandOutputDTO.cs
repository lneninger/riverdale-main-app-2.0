using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models
{
    public class ProductAllowedColorTypePageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductColorTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}