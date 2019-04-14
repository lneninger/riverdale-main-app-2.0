using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand
{
    public class ProductAllowedColorTypeUpdateCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypeUpdateCommand
    {
        public ProductAllowedColorTypeUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductAllowedColorTypeUpdateCommandOutputDTO> Execute(ProductAllowedColorTypeUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductAllowedColorTypeUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.ProductColorTypeId = input.ProductColorTypeId;
                    
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Allowed Color Type Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductAllowedColorTypeUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductCategoryId = getByIdResult.Bag.ProductCategoryId,
                            ProductColorTypeId = getByIdResult.Bag.ProductColorTypeId,
                        };
                    }

                }
            }

            return result;
        }
    }
}
