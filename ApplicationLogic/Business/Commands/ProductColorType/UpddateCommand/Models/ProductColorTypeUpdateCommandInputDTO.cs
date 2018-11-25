using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models
{
    public class ProductColorTypeUpdateCommandInputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsBasicColor { get; set; }
    }
}