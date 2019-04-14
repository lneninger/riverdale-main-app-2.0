using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models
{
    public class ProductAllowedColorTypeGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string ProductColorTypeId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}