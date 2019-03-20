using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand
{
    public class SaleOpportunityTargetPriceGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPriceGetByIdCommand
    {

        public SaleOpportunityTargetPriceGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityTargetPriceGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        TargetPrice = getByIdResult.Bag.TargetPrice,
                        SaleSeasonTypeId = getByIdResult.Bag.SaleSeasonTypeId,
                        SampleBoxes = getByIdResult.Bag.SampleBoxes.Select(o => o.Id),
                        SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
                        SaleOpportunityTargetPriceProducts = getByIdResult.Bag.SaleOpportunityTargetPriceProducts.Select(o => o.Id),
                    };
                }
            }

            return result;
        }
    }
}
