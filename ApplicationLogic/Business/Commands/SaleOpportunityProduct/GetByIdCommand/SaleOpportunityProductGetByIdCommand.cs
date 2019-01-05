using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand
{
    public class SaleOpportunityProductGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductGetByIdCommand
    {

        public SaleOpportunityProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityProductGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityProductGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductAmmount = getByIdResult.Bag.ProductAmount,
                        SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
                        RelatedProductId = getByIdResult.Bag.ProductId,
                    };
                }
            }

            return result;
        }
    }
}
