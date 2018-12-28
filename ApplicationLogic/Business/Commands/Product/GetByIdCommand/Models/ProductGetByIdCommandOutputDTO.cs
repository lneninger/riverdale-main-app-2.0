﻿using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.Product.Commons;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models
{
    public class ProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public string Stems { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

    }
}