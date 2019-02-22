using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand.Models
{
    public class SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmmount { get; set; }

        public int SaleOpportunityPriceLevelId { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
