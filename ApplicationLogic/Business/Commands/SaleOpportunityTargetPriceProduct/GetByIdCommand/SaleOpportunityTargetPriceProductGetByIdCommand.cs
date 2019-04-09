using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand
{
    public class SaleOpportunityTargetPriceProductGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPriceProduct, ISaleOpportunityTargetPriceProductDBRepository>, ISaleOpportunityTargetPriceProductGetByIdCommand
    {

        public SaleOpportunityTargetPriceProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductAmmount = getByIdResult.Bag.ProductAmount,
                        TargetPriceId = getByIdResult.Bag.SaleOpportunityTargetPriceId,
                        RelatedProductId = getByIdResult.Bag.ProductId,
                    };
                }
            }

            return result;
        }
    }
}
