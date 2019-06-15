using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models
{
    public class ProductsUpdateCommandOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}