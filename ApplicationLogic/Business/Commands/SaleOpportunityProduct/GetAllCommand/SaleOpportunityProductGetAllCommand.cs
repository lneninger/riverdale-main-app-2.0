using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetAllCommand
{
    public class SaleOpportunityProductGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductGetAllCommand
    {
        public SaleOpportunityProductGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityProductGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityProductGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SaleOpportunityProductGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        ProductAmount = entityItem.ProductAmount,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
