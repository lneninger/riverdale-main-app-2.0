using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand
{
    public class SaleOpportunityPriceLevelProductDeleteCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductDeleteCommand
    {
        public SaleOpportunityPriceLevelProductDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelProductDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProductDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityPriceLevelProductDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        SaleOpportunityPriceLevelId = getByIdResult.Bag.SaleOpportunityPriceLevelId,
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
