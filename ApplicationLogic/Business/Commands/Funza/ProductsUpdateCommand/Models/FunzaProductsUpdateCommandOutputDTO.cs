using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models
{
    public class FunzaProductsUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}