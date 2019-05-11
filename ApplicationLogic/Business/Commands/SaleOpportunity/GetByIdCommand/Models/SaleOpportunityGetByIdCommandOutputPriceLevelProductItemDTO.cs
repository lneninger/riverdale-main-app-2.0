using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputTargetPriceProductItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
        public int ProductPictureId { get; internal set; }
        public string ProductColorTypeId { get; set; }
        public string ProductColorTypeName { get; set; }
        public int OpportunityCount { get; set; }
        public int FirstOpportunityId { get; set; }
        public List<SaleOpportunityGetByIdCommandOutputRelatedProductItemDTO> RelatedProducts { get; set; }
        public string FirstOpportunityName { get; set; }
    }
}
