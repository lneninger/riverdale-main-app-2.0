using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models
{
    public class ProductColorTypeGetByIdCommandOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsBasicColor { get; set; }
    }
}