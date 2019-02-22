using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand
{
    public class SaleOpportunityPriceLevelProductInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevelProduct, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductInsertCommand
    {
        public SaleOpportunityPriceLevelProductInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelProductInsertCommandOutputDTO> Execute(SaleOpportunityPriceLevelProductInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProductInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunityPriceLevelProduct
                {
                    Product = new CompositionProduct {
                        Name = input.Name
                    },
                    SaleOpportunityPriceLevelId = input.SaleOpportunityPriceLevelId,
                    ProductColorTypeId = input.ProductColorTypeId
                };

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding Product", ex);
                }

                if (result.IsSucceed)
                {
                    //this.Repository.Detach(entity.Id);
                    var getByIdResult = this.Repository.GetById(entity.Id, true);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {

                        result.Bag = new SaleOpportunityPriceLevelProductInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.ProductId,
                            SaleOpportunityPriceLevelId = getByIdResult.Bag.SaleOpportunityPriceLevelId,
                            ProductAmount = getByIdResult.Bag.ProductAmount,
                            ProductName = getByIdResult.Bag.Product.Name,
                            ProductTypeId = getByIdResult.Bag.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                        };
                    }

                }
            }

            return result;
        }
    }
}
