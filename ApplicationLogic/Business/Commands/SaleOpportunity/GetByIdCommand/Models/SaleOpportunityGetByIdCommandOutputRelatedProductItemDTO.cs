namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models
{
    public class SaleOpportunityGetByIdCommandOutputRelatedProductItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RelatedProductId { get; set; }
        public int RelatedProductAmount { get; set; }
        public string RelatedProductName { get; set; }
        public string RelatedProductTypeName { get; set; }
        public string RelatedProductTypeDescription { get; set; }
        public int RelatedProductPictureId { get; set; }
        public string RelatedProductTypeId { get; set; }
        public int? RelatedProductSizeId { get; set; }
        public string ColorTypeId { get; set; }
        public int? RelatedProductCategoryId { get; set; }
    }
}