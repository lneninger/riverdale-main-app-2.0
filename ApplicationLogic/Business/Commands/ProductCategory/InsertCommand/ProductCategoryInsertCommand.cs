using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategory.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategory.InsertCommand
{
    public class ProductCategoryInsertCommand : AbstractDBCommand<DomainModel.Product.ProductCategory, IProductCategoryDBRepository>, IProductCategoryInsertCommand
    {
        public ProductCategoryInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryInsertCommandOutputDTO> Execute(ProductCategoryInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductCategoryInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                var entity = new DomainModel.Product.ProductCategory
                    {
                        Identifier = input.Identifier,
                        Name = input.Name,
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
                    result.AddError("Error Adding ProductCategory", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductCategoryInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Identifier = getByIdResult.Bag.Identifier,
                            Name = getByIdResult.Bag.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
