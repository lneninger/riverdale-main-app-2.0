using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand
{
    public class SaleOpportunityPriceLevelUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISaleOpportunityPriceLevelDBRepository>, ISaleOpportunityPriceLevelUpdateCommand
    {
        public SaleOpportunityPriceLevelUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelUpdateCommandOutputDTO> Execute(SaleOpportunityPriceLevelUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelUpdateCommandOutputDTO>();
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
                        result.Bag = new SaleOpportunityPriceLevelUpdateCommandOutputDTO
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
            }

            return result;
        }
    }
}
