using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models
{
    public class SampleBoxProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int SaleOpportunityPriceLevelProductId { get; set; }

        public int Order { get; set; }

    }
}