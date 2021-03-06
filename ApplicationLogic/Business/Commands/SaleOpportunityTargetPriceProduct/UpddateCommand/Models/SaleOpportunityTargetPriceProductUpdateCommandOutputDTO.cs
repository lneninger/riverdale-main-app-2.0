﻿using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand.Models
{
    public class SaleOpportunityTargetPriceProductUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public int TargetPriceId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductColorTypeId { get; set; }

        public int ProductId { get; internal set; }

        public string ProductName { get; set; }

        public int ProductPictureId { get; set; }

        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }

        public string ProductColorTypeName { get; set; }
    }
}