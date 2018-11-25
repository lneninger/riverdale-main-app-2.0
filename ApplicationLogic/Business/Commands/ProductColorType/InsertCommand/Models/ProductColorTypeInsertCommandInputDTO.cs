using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models
{
    public class ProductColorTypeInsertCommandInputDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public bool IsBasicColor { get; set; }
    }
}