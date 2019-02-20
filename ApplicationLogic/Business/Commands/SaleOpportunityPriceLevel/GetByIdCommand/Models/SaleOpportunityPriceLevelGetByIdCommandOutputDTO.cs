using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand.Models
{
    public class SaleOpportunityPriceLevelGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
