using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand
{
    public class ProductAllowedColorTypeInsertCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypeInsertCommand
    {
        public ProductAllowedColorTypeInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductAllowedColorTypeInsertCommandOutputDTO> Execute(ProductAllowedColorTypeInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductAllowedColorTypeInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Product.ProductCategoryAllowedColorType
                    {
                        ProductId = input.ProductId,
                        ProductColorTypeId = input.ProductColorTypeId,
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
                        result.Bag = new ProductAllowedColorTypeInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.ProductId,
                            ProductColorTypeId = getByIdResult.Bag.ProductColorTypeId,
                        };
                    }

                }
            }

            return result;
        }
    }
}
