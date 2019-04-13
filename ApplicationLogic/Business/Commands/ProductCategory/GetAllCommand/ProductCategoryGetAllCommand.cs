using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand
{
    public class ProductCategoryGetAllCommand : AbstractDBCommand<DomainModel.Product.ProductCategory, IProductCategoryDBRepository>, IProductCategoryGetAllCommand
    {
        public ProductCategoryGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductCategoryGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<ProductCategoryGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new ProductCategoryGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
