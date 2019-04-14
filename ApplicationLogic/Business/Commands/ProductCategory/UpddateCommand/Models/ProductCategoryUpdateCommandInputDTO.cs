using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.UpdateCommand.Models
{
    public class ProductCategoryUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }
    }
}