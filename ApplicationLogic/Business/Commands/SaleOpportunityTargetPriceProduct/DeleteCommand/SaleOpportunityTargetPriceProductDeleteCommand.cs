using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand
{
    public class SaleOpportunityTargetPriceProductDeleteCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceProductDBRepository>, ISaleOpportunityTargetPriceProductDeleteCommand
    {
        public SaleOpportunityTargetPriceProductDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceProductDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceProductDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityTargetPriceProductDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        TargetPriceId = getByIdResult.Bag.SaleOpportunityTargetPriceId,
                        ProductId = getByIdResult.Bag.ProductId
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
