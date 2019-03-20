using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand
{
    public class SaleOpportunityTargetPriceGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPriceGetAllCommand
    {
        public SaleOpportunityTargetPriceGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityTargetPriceGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityTargetPriceGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SaleOpportunityTargetPriceGetAllCommandOutputDTO
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
