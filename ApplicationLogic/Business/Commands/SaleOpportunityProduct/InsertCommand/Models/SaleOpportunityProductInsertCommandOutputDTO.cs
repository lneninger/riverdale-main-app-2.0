using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand.Models
{
    public class SaleOpportunityProductInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SaleOpportunityId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductName { get; set; }

        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }

        public int ProductPictureId { get; set; }
    }
}