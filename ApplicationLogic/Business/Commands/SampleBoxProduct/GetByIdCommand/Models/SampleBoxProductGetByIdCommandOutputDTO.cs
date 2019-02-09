using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand.Models
{
    public class SampleBoxProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmmount { get; set; }

        public int SampleBoxId { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
