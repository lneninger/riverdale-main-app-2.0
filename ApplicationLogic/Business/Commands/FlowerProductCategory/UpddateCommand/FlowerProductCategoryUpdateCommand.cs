using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand
{
    public class FlowerProductCategoryUpdateCommand : AbstractDBCommand<DomainModel.Product.FlowerProductCategory, IFlowerProductCategoryDBRepository>, IFlowerProductCategoryUpdateCommand
    {
        public FlowerProductCategoryUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFlowerProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FlowerProductCategoryUpdateCommandOutputDTO> Execute(FlowerProductCategoryUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<FlowerProductCategoryUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Name = input.Name;
                    getByIdResult.Bag.Id = input.Id;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating FlowerProductCategory Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new FlowerProductCategoryUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
