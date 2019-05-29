using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand
{
    public class ProductBridgeUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductBridgeDBRepository>, IProductBridgeUpdateCommand
    {
        public ProductBridgeUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductBridgeUpdateCommandOutputDTO> Execute(ProductBridgeUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductBridgeUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.CompositionItemAmount = input.RelatedProductAmount;
                    getByIdResult.Bag.ColorTypeId = input.ColorTypeId;
                    getByIdResult.Bag.ProductCategorySizeId = input.RelatedProductSizeId;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating composition item", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductBridgeUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.CompositionProductId,
                            RelatedProductAmount = getByIdResult.Bag.CompositionItemAmount,
                            RelatedProductSizeId = getByIdResult.Bag.ProductCategorySizeId,
                            ColorTypeId = getByIdResult.Bag.ColorTypeId,

                            RelatedProductId = getByIdResult.Bag.CompositionItemId,
                            RelatedProductName = getByIdResult.Bag.CompositionItem.Name,
                            RelatedProductTypeName = getByIdResult.Bag.CompositionItem.ProductType.Name,
                            RelatedProductTypeDescription = getByIdResult.Bag.CompositionItem.ProductType.Description,
                            RelatedProductPictureId = getByIdResult.Bag.CompositionItem.ProductMedias.Where(m => m.IsDeleted == null || m.IsDeleted == false).Select(media => media.FileRepositoryId).FirstOrDefault(),
                            RelatedProductTypeId = getByIdResult.Bag.CompositionItem.ProductTypeId,
                            RelatedProductCategoryId = getByIdResult.Bag.CompositionItem.ProductCategoryId
                        };
                    }

                }
            }

            return result;
        }
    }
}
