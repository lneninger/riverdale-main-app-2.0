using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand
{
    public class SampleBoxProductGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBoxProduct, ISampleBoxProductDBRepository>, ISampleBoxProductGetAllCommand
    {
        public SampleBoxProductGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SampleBoxProductGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SampleBoxProductGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SampleBoxProductGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        ProductAmount = entityItem.SaleOpportunityPriceLevelProduct.ProductAmount,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
