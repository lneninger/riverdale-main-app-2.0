using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand
{
    public class SaleOpportunityPriceLevelProductGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevelProduct, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductGetAllCommand
    {
        public SaleOpportunityPriceLevelProductGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityPriceLevelProductGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityPriceLevelProductGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SaleOpportunityPriceLevelProductGetAllCommandOutputDTO
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
