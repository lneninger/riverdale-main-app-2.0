using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand
{
    public class SaleOpportunityPriceLevelProductUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductUpdateCommand
    {
        public SaleOpportunityPriceLevelProductUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelProductUpdateCommandOutputDTO> Execute(SaleOpportunityPriceLevelProductUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProductUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.ProductAmount = input.ProductAmount;
                    getByIdResult.Bag.ProductColorTypeId = input.ProductColorTypeId;
                    getByIdResult.Bag.Order = input.Order;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityPriceLevelProductUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            SaleOpportunityPriceLevelId = getByIdResult.Bag.SaleOpportunityPriceLevelId,
                            ProductId = getByIdResult.Bag.ProductId,
                            ProductAmount = getByIdResult.Bag.ProductAmount,
                            ProductName = getByIdResult.Bag.Product.Name,
                            ProductTypeId = getByIdResult.Bag.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                            ProductColorTypeId = getByIdResult.Bag.ProductColorTypeId,
                            ProductColorTypeName = getByIdResult.Bag.ProductColorType?.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
