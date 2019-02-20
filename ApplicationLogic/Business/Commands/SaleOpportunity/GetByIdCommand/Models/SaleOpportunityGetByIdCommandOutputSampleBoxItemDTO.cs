using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO
    {
        public int Id { get; set; }

        public int SaleOpportunityPriceLevelId { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public List<SaleOpportunityGetByIdCommandOutputSampleBoxProductItemDTO> SampleBoxSaleOpportunityProductIds { get; set; }

        //public int ProductAmount { get; set; }

        //public string ProductColorTypeId { get; set; }

        //public int ProductId { get; internal set; }

        //public string ProductName { get; set; }

        //public int ProductPictureId { get; set; }

        //public string ProductTypeId { get; set; }

        //public string ProductTypeName { get; set; }

        //public string ProductTypeDescription { get; set; }
    }
}
