using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand
{
    public class ProductAllowedColorTypeGetAllCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypeGetAllCommand
    {
        public ProductAllowedColorTypeGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductAllowedColorTypeGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<ProductAllowedColorTypeGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new ProductAllowedColorTypeGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        ProductName = entityItem.Product.Name,
                        ProductColortTypeName = entityItem.ProductColorType.Name,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
