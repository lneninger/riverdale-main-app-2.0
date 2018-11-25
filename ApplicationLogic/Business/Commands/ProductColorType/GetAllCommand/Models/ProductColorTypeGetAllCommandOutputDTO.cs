using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models
{
    public class ProductColorTypeGetAllCommandOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsBasicColor{ get; set; }
    }
}