using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string SeasonName { get; set; }

        public decimal? TargetPrice { get; set; }

        public string SaleOpportunityTypeId { get; set; }

        public SaleOpportunityGetByIdCommandOutputSettingsDTO Settings { get; set; }


        public IEnumerable<SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO> RelatedProducts { get; internal set; }
    }
}