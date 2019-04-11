using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand
{
    public class FlowerProductCategoryGetAllCommand : AbstractDBCommand<DomainModel.Product.FlowerProductCategory, IFlowerProductCategoryDBRepository>, IFlowerProductCategoryGetAllCommand
    {
        public FlowerProductCategoryGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IFlowerProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<FlowerProductCategoryGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FlowerProductCategoryGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new FlowerProductCategoryGetAllCommandOutputDTO
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
