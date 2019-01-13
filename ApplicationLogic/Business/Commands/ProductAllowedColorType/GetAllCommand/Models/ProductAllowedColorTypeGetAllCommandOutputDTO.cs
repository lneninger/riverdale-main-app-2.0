using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand.Models
{
    public class ProductAllowedColorTypeGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductColortTypeName { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}