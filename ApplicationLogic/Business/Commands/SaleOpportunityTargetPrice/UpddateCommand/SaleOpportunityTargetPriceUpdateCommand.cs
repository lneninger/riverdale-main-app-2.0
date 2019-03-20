using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.UpdateCommand
{
    public class SaleOpportunityTargetPriceUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPriceUpdateCommand
    {
        public SaleOpportunityTargetPriceUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceUpdateCommandOutputDTO> Execute(SaleOpportunityTargetPriceUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.TargetPrice = input.TargetPrice;
                    getByIdResult.Bag.SaleSeasonTypeId = input.SaleSeasonTypeId;
                    getByIdResult.Bag.IsDeleted = input.IsDeleted;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Sample Box", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityTargetPriceUpdateCommandOutputDTO
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
            }

            return result;
        }
    }
}
