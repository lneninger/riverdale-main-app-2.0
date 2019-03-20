using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand
{
    public class SaleOpportunityTargetPriceDeleteCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPriceDeleteCommand
    {
        public SaleOpportunityTargetPriceDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityTargetPriceDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        SaleSeasonTypeId = getByIdResult.Bag.SaleSeasonTypeId,
                        TargetPrice = getByIdResult.Bag.TargetPrice
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
                        result.AddException("Error deleting Product", ex);
                    }
                }
            }

            return result;
        }
    }
}
