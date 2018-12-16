using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models
{
    public class ProductMediaDeleteCommandOutputDTO
    {

        public ProductMediaDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}