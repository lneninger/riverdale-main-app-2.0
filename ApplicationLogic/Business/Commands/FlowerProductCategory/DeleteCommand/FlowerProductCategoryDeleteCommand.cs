using ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand.Models;
using ApplicationLogic.Repositories.DB;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand
{
    public class FlowerProductCategoryDeleteCommand : AbstractDBCommand<DomainModel.Product.FlowerProductCategory, IFlowerProductCategoryDBRepository>, IFlowerProductCategoryDeleteCommand
    {
        public FlowerProductCategoryDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IFlowerProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FlowerProductCategoryDeleteCommandOutputDTO> Execute(string id)
        {
            var result = new OperationResponse<FlowerProductCategoryDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new FlowerProductCategoryDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
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
