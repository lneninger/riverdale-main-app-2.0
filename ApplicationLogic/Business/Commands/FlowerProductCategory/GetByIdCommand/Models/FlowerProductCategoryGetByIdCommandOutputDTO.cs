using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models
{
    public class FlowerProductCategoryGetByIdCommandOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        //public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        
        
        public IEnumerable<FlowerProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO> FlowerProductCategoryAllowedColorTypes { get; internal set; }
    }
}