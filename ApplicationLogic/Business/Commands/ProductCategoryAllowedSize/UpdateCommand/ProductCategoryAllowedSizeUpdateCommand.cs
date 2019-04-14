using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand
{
    public class ProductCategoryAllowedSizeUpdateCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizeUpdateCommand
    {
        public ProductCategoryAllowedSizeUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryAllowedSizeUpdateCommandOutputDTO> Execute(ProductCategoryAllowedSizeUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductCategoryAllowedSizeUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Size = input.Size;
                    
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
                        result.Bag = new ProductCategoryAllowedSizeUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductCategoryId = getByIdResult.Bag.ProductCategoryId,
                            Size = getByIdResult.Bag.Size,
                        };
                    }

                }
            }

            return result;
        }
    }
}
