using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand
{
    public class SaleOpportunityPriceLevelGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel, ISaleOpportunityPriceLevelDBRepository>, ISaleOpportunityPriceLevelGetAllCommand
    {
        public SaleOpportunityPriceLevelGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityPriceLevelGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityPriceLevelGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SaleOpportunityPriceLevelGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        TargetPrice = entityItem.TargetPrice,
                        SaleSeasonTypeId = entityItem.SaleSeasonTypeId,

                        SaleOpportunityId = entityItem.SaleOpportunityId,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
