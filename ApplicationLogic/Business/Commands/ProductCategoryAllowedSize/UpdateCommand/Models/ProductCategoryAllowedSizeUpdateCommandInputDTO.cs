using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models
{
    public class ProductCategoryAllowedSizeUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Size { get; set; }
    }
}