using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models
{
    public class ProductCategoryAllowedSizeGetByIdCommandOutputRelatedProductCategoryAllowedSizeItemDTO
    {
        public int Id { get; set; }

        public int ProductCategoryAllowedSizeId { get; set; }

        public int RelatedProductCategoryAllowedSizeId { get; set; }

        public int Stems { get; set; }

        public string RelatedProductCategoryAllowedSizeName { get; set; }

        public string RelatedProductCategoryAllowedSizeTypeName { get; set; }

        public string RelatedProductCategoryAllowedSizeTypeDescription { get; set; }

        public int RelatedProductCategoryAllowedSizePictureId { get; set; }
    }
}
