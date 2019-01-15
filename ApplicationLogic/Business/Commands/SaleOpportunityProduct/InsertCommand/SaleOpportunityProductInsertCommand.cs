using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand
{
    public class SaleOpportunityProductInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductInsertCommand
    {
        public SaleOpportunityProductInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityProductInsertCommandOutputDTO> Execute(SaleOpportunityProductInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityProductInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunityProduct
                {
                    SaleOpportunityId = input.SaleOpportunityId,
                    ProductId = input.ProductId,
                    ProductAmount = input.ProductAmount
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

                        result.Bag = new SaleOpportunityProductInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.ProductId,
                            SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
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
