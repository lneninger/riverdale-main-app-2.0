using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBox.InsertCommand
{
    public class SampleBoxInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBox, ISampleBoxDBRepository>, ISampleBoxInsertCommand
    {
        public SampleBoxInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxInsertCommandOutputDTO> Execute(SampleBoxInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SampleBoxInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SampleBox
                {
                    Order = input.Order,
                    Name = input.Name,
                    SaleOpportunityPriceLevelId = input.SaleOpportunityPriceLevelId
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

                        result.Bag = new SampleBoxInsertCommandOutputDTO
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
