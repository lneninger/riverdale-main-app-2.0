using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.DeleteCommand.Models
{
    public class SampleBoxProductDeleteCommandOutputDTO
    {

        public SampleBoxProductDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int SaleOpportunityPriceLevelProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}