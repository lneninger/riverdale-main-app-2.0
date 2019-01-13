﻿using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models
{
    public class ProductAllowedColorTypeInsertCommandInputDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductColorTypeId { get; set; }
    }
}