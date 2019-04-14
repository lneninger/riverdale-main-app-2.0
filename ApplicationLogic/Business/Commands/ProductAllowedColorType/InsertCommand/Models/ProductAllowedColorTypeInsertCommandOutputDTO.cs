﻿using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models
{
    public class ProductAllowedColorTypeInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductColorTypeId { get; set; }
    }
}