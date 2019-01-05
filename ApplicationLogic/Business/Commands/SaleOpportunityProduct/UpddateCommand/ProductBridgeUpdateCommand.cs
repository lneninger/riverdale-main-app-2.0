using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand
{
    public class SaleOpportunityProductUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductUpdateCommand
    {
        public SaleOpportunityProductUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityProductUpdateCommandOutputDTO> Execute(SaleOpportunityProductUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityProductUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.ProductAmount = input.ProductAmmount;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityProductUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                        };
                    }

                }
            }

            return result;
        }
    }
}
