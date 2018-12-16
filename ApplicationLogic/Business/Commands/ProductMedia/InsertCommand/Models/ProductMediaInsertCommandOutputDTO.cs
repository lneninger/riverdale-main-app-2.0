using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models
{
    public class ProductMediaInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}