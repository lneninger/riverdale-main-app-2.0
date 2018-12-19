using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models
{
    public class ProductColorTypeDeleteCommandOutputDTO
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public bool IsBasicColor { get; set; }
    }
}