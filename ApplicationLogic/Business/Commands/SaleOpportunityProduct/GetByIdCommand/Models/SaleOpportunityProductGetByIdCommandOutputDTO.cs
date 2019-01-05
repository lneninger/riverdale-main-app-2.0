using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand.Models
{
    public class SaleOpportunityProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmmount { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        public int SaleOpportunityId { get; internal set; }
    }
}
