using System;

namespace ApplicationLogic.Business.Commands.Product.UpdateCommand.Models
{
    public class ProductUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}