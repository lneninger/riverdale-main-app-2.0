using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand
{
    public class ProductAllowedColorTypeDeleteCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypeDeleteCommand
    {
        public ProductAllowedColorTypeDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductAllowedColorTypeDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductAllowedColorTypeDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductAllowedColorTypeDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductName = getByIdResult.Bag.ProductCategory?.Name,
                        ProductColorTypeName = getByIdResult.Bag.ProductColorType?.Name
                    };
                }

                var deleteResult = this.Repository.Delete(getByIdResult.Bag);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Product allowed color type", ex);
                    }
                }
            }

            return result;
        }
    }
}
