﻿using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand.Models
{
    public class SaleOpportunityPriceLevelUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SaleSeasonTypeId { get; set; }
        public int Order { get; set; }
        public decimal? TargetPrice { get; set; }
        public bool? IsDeleted { get; set; }
    }
}