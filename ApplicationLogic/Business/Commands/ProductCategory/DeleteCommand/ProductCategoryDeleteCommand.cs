using ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand.Models;
using ApplicationLogic.Repositories.DB;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand
{
    public class ProductCategoryDeleteCommand : AbstractDBCommand<DomainModel.Product.ProductCategory, IProductCategoryDBRepository>, IProductCategoryDeleteCommand
    {
        public ProductCategoryDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductCategoryDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductCategoryDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Identifier = getByIdResult.Bag.Identifier,
                        Name = getByIdResult.Bag.Name
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
                        result.AddException("Error deleting Flower Category", ex);
                    }
                }
            }

            return result;
        }
    }
}
