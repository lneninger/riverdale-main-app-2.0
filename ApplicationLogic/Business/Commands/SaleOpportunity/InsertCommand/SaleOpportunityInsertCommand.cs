using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand
{
    public class SaleOpportunityInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunity, ISaleOpportunityDBRepository>, ISaleOpportunityInsertCommand
    {
        public SaleOpportunityInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityInsertCommandOutputDTO> Execute(SaleOpportunityInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunity
                {
                    Name = input.Name,
                    //SaleSeasonTypeId = input.SaleSeasonTypeId,
                    CustomerId = input.CustomerId,
                    //TargetPrice = input.TargetPrice
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
                    result.AddError("Error Adding SaleOpportunity", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityInsertCommandOutputDTO
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
