using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand
{
    public class SaleOpportunityUpdateCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunity, ISaleOpportunityDBRepository>, ISaleOpportunityUpdateCommand
    {
        public SaleOpportunityUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityUpdateCommandOutputDTO> Execute(SaleOpportunityUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Name = input.Name;
                    getByIdResult.Bag.SaleSeasonTypeId = input.SaleSeasonTypeId;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating SaleOpportunity Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
