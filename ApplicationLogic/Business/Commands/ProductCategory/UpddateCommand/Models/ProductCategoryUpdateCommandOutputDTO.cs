using System;

namespace ApplicationLogic.Business.Commands.ProductCategory.UpdateCommand.Models
{
    public class ProductCategoryUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }
    }
}