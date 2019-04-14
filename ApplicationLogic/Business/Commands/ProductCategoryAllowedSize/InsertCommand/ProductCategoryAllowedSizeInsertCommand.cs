using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand
{
    public class ProductCategoryAllowedSizeInsertCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizeInsertCommand
    {
        public ProductCategoryAllowedSizeInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryAllowedSizeInsertCommandOutputDTO> Execute(ProductCategoryAllowedSizeInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductCategoryAllowedSizeInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Product.ProductCategoryAllowedSize
                    {
                        ProductCategoryId = input.ProductCategoryId,
                        Size = input.Size,
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
                    result.AddError("Error Adding Product Allowed Color Type", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductCategoryAllowedSizeInsertCommandOutputDTO
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
