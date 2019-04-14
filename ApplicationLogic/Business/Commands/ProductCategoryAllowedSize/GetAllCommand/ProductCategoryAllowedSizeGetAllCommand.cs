using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand
{
    public class ProductCategoryAllowedSizeGetAllCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizeGetAllCommand
    {
        public ProductCategoryAllowedSizeGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductCategoryAllowedSizeGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<ProductCategoryAllowedSizeGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new ProductCategoryAllowedSizeGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        ProductName = entityItem.ProductCategory.Name,
                        Size = entityItem.Size,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
