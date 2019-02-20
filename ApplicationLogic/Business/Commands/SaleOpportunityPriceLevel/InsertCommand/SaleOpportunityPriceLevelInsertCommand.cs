using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand
{
    public class SaleOpportunityPriceLevelInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel, ISaleOpportunityPriceLevelDBRepository>, ISaleOpportunityPriceLevelInsertCommand
    {
        public SaleOpportunityPriceLevelInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelInsertCommandOutputDTO> Execute(SaleOpportunityPriceLevelInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunityPriceLevel
                {
                    TargetPrice = input.TargetPrice,
                    SaleSeasonTypeId = input.SaleSeasonTypeId,
                };

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error adding Sample Box", ex);
                }

                if (result.IsSucceed)
                {
                    //this.Repository.Detach(entity.Id);
                    var getByIdResult = this.Repository.GetById(entity.Id, true);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityPriceLevelInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Order = getByIdResult.Bag.Order,
                            Name = getByIdResult.Bag.Name,
                            SaleOpportunityPriceLevelId = getByIdResult.Bag.SaleOpportunityPriceLevelId
                        };
                    }

                }
            }

            return result;
        }
    }
}
