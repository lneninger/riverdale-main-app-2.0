using System;

namespace ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models
{
    public class ProductBridgeUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductAmount { get; set; }

        public int? RelatedProductSizeId { get; set; }

        public string ColorTypeId { get; set; }

        public string RelatedProductTypeName { get; set; }

        public string RelatedProductName { get; set; }

        public int RelatedProductId { get; set; }

        public string RelatedProductTypeDescription { get; set; }

        public object RelatedProductPictureId { get; set; }

        public string RelatedProductTypeId { get; set; }

        public int? RelatedProductCategoryId { get; set; }
    }
}