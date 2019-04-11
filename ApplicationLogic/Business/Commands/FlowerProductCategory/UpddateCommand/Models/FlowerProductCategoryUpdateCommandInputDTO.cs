using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand.Models
{
    public class FlowerProductCategoryUpdateCommandInputDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }
}