using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand
{
    public class FlowerProductCategoryInsertCommand : AbstractDBCommand<DomainModel.Product.FlowerProductCategory, IFlowerProductCategoryDBRepository>, IFlowerProductCategoryInsertCommand
    {
        public FlowerProductCategoryInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IFlowerProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FlowerProductCategoryInsertCommandOutputDTO> Execute(FlowerProductCategoryInsertCommandInputDTO input)
        {
            var result = new OperationResponse<FlowerProductCategoryInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                var entity = new DomainModel.Product.FlowerProductCategory
                    {
                        Id = input.Id,
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
                    result.AddError("Error Adding FlowerProductCategory", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new FlowerProductCategoryInsertCommandOutputDTO
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
