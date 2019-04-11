using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models
{
    public class FlowerProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO
    {
        public int Id { get; set; }
        public object FlowerProductCategoryColorTypeId { get; internal set; }
    }
}
