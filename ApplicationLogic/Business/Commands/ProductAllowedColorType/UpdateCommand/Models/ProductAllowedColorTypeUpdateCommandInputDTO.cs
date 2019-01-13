using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models
{
    public class ProductAllowedColorTypeUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string ProductColorTypeId { get; set; }
    }
}