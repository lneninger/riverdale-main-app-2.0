using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductName { get; set; }

        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }

        public int ProductPictureId { get; set; }

        public int ProductId { get; internal set; }
    }
}
