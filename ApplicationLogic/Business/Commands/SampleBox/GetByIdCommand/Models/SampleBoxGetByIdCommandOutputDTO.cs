using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand.Models
{
    public class SampleBoxGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
