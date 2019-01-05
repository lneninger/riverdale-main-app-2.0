using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SaleOpportunityColorTypeId { get; set; }

        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        public string SaleOpportunityTypeId { get; set; }
        

        public IEnumerable<SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO> RelatedProducts { get; internal set; }
    }
}