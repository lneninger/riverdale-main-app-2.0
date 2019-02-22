using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand
{
    public class SaleOpportunityPriceLevelGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel, ISaleOpportunityPriceLevelDBRepository>, ISaleOpportunityPriceLevelGetByIdCommand
    {

        public SaleOpportunityPriceLevelGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityPriceLevelGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        TargetPrice = getByIdResult.Bag.TargetPrice,
                        SaleSeasonTypeId = getByIdResult.Bag.SaleSeasonTypeId,
                        SampleBoxes = getByIdResult.Bag.SampleBoxes.Select(o => o.Id),
                        SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
                        SaleOpportunityPriceLevelProducts = getByIdResult.Bag.SaleOpportunityPriceLevelProducts.Select(o => o.Id),
                    };
                }
            }

            return result;
        }
    }
}
