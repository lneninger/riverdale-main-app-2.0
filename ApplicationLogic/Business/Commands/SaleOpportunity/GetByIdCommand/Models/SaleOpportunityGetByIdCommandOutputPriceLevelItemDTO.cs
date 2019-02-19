using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputPriceLevelItemDTO
    {
        public string SeasonName { get; set; }
        public decimal? TargetPrice { get; set; }
        public SaleOpportunityGetByIdCommandOutputSettingsDTO Settings { get; set; }
        public IEnumerable<SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO> SampleBoxes { get; set; }
        public IEnumerable<SaleOpportunityGetByIdCommandOutputProductItemDTO> SaleOpportunityProducts { get; set; }

        

    }
}
