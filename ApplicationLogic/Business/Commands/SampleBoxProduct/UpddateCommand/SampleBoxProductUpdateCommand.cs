using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand
{
    public class SampleBoxProductUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISampleBoxProductDBRepository>, ISampleBoxProductUpdateCommand
    {
        public SampleBoxProductUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxProductUpdateCommandOutputDTO> Execute(SampleBoxProductUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SampleBoxProductUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
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
                        result.Bag = new SampleBoxProductUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            SampleBoxId = getByIdResult.Bag.SampleBoxId,
                            ProductId = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.ProductId,
                            ProductAmount = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.ProductAmount,
                            ProductName = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.Product.Name,
                            ProductTypeId = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                            ProductColorTypeId = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.ProductColorTypeId,
                            ProductColorTypeName = getByIdResult.Bag.SaleOpportunityTargetPriceProduct.ProductColorType?.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
