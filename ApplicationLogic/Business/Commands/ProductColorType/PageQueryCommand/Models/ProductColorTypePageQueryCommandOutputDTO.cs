using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models
{
    public class ProductColorTypePageQueryCommandOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsBasicColor { get; set; }
    }
}