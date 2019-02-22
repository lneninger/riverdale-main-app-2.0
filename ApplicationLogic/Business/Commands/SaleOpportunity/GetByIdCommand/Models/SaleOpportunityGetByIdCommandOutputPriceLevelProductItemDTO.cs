using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputPriceLevelProductItemDTO
    {
        public int Id { get; internal set; }
        public int ProductId { get; internal set; }
        public int ProductAmount { get; internal set; }
        public string ProductName { get; internal set; }
        public string ProductTypeId { get; internal set; }
        public string ProductTypeName { get; internal set; }
        public string ProductTypeDescription { get; internal set; }
        public int ProductPictureId { get; internal set; }
        public string ProductColorTypeId { get; internal set; }
        public string ProductColorTypeName { get; internal set; }
    }
}
