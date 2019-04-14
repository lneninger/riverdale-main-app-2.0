using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models
{
    public class ProductCategoryGetByIdCommandOutputDTO
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        //public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        
        
        public IEnumerable<ProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO> AllowedColors { get; set; }

        public IEnumerable<ProductCategoryGetByIdCommandOutputAllowedSizeItemDTO> AllowedSizes { get; set; }
    }
}