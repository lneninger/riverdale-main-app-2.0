using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand.Models
{
    public class ProductAllowedColorTypeDeleteCommandOutputDTO
    {

        public ProductAllowedColorTypeDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductColorTypeName { get; set; }
    }
}