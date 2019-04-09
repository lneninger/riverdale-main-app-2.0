using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand.Models
{
    public class SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmmount { get; set; }

        public int TargetPriceId { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
    }
}
