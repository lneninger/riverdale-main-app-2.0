﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models
{
    public class ProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO
    {
        public int Id { get; set; }
        public object ProductColorTypeId { get; internal set; }
    }
}
