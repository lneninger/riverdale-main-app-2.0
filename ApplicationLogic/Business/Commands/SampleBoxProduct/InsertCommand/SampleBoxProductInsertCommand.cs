using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand
{
    public class SampleBoxProductInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBoxProduct, ISampleBoxProductDBRepository>, ISampleBoxProductInsertCommand
    {
        public SampleBoxProductInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxProductInsertCommandOutputDTO> Execute(SampleBoxProductInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SampleBoxProductInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SampleBoxProduct
                {
                    SampleBoxId = input.SampleBoxId,
                    SaleOpportunityProductId = input.SaleOpportunityProductId
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

                        result.Bag = new SampleBoxProductInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.SaleOpportunityProductId,
                            SampleBoxId = getByIdResult.Bag.SampleBoxId,
                            ProductAmount = getByIdResult.Bag.SaleOpportunityProduct.ProductAmount,
                            ProductName = getByIdResult.Bag.SaleOpportunityProduct.Product.Name,
                            ProductTypeId = getByIdResult.Bag.SaleOpportunityProduct.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.SaleOpportunityProduct.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.SaleOpportunityProduct.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.SaleOpportunityProduct.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                        };
                    }

                }
            }

            return result;
        }
    }
}
