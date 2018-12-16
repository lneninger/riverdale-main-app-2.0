using System;

namespace ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand.Models
{
    public class ProductMediaUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}