using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models
{
    public class ProductCategoryGetByIdCommandOutputRelatedProductCategoryItemDTO
    {
        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public int RelatedProductCategoryId { get; set; }

        public int Stems { get; set; }

        public string RelatedProductCategoryName { get; set; }

        public string RelatedProductCategoryTypeName { get; set; }

        public string RelatedProductCategoryTypeDescription { get; set; }

        public int RelatedProductCategoryPictureId { get; set; }
    }
}
