using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand
{
    public class ProductCategoryAllowedSizeDeleteCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizeDeleteCommand
    {
        public ProductCategoryAllowedSizeDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryAllowedSizeDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductCategoryAllowedSizeDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductCategoryAllowedSizeDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductName = getByIdResult.Bag.ProductCategory?.Name,
                        Size = getByIdResult.Bag.Size
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
