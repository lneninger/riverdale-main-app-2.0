﻿using System;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models
{
    public class ProductAllowedColorTypeUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductColorTypeId { get; set; }
    }
}