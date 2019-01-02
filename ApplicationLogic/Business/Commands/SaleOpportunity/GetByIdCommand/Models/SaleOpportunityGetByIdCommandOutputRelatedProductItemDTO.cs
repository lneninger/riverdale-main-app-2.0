using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int RelatedSaleOpportunityId { get; set; }

        public int Stems { get; set; }

        public string RelatedSaleOpportunityName { get; set; }

        public string RelatedSaleOpportunityTypeName { get; set; }

        public string RelatedSaleOpportunityTypeDescription { get; set; }

        public int RelatedSaleOpportunityPictureId { get; set; }
    }
}
