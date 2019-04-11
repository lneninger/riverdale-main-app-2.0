using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models
{
    public class FlowerProductCategoryGetByIdCommandOutputRelatedFlowerProductCategoryItemDTO
    {
        public int Id { get; set; }

        public int FlowerProductCategoryId { get; set; }

        public int RelatedFlowerProductCategoryId { get; set; }

        public int Stems { get; set; }

        public string RelatedFlowerProductCategoryName { get; set; }

        public string RelatedFlowerProductCategoryTypeName { get; set; }

        public string RelatedFlowerProductCategoryTypeDescription { get; set; }

        public int RelatedFlowerProductCategoryPictureId { get; set; }
    }
}
