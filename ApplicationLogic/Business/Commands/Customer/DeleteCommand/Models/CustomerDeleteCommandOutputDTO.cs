using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models
{
    public class ProductColorDeleteCommandOutputDTO
    {

        public ProductColorDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}