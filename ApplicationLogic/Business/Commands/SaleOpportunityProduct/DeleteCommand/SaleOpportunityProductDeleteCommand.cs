using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand
{
    public class SaleOpportunityProductDeleteCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductDeleteCommand
    {
        public SaleOpportunityProductDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityProductDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityProductDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityProductDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
                        RelatedProductId = getByIdResult.Bag.ProductId
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
