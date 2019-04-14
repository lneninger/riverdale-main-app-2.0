using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models
{
    public class ProductCategoryAllowedSizeGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int ProductCategoryId { get; set; }
    }
}