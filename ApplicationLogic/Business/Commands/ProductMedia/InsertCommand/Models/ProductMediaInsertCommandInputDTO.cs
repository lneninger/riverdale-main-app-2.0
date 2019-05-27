using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models
{
    public class ProductMediaInsertCommandInputDTO: UploadedFile
    {
        public int ProductId { get; set; }

        public bool? SaveAsGrayscale { get; set; }
    }
}