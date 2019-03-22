using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputTargetPriceItemDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string SeasonName { get; set; }
        public decimal? TargetPrice { get; set; }
        public int AlternativesAmount { get; set; }
        public int SaleSeasonTypeId { get; set; }
        public SaleOpportunityGetByIdCommandOutputSettingsDTO Settings { get; set; }
        public IEnumerable<SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO> SampleBoxes { get; set; }
        public IEnumerable<SaleOpportunityGetByIdCommandOutputTargetPriceProductItemDTO> SaleOpportunityTargetPriceProducts { get; set; }
    }
}
