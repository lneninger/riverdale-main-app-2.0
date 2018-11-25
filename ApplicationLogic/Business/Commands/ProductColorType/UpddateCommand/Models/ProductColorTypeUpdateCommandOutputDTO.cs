using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models
{
    public class ProductColorTypeUpdateCommandOutputDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public bool IsBasicColor { get; set; }
    }
}