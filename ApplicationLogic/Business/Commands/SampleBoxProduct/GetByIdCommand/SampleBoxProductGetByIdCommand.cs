using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand
{
    public class SampleBoxProductGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBoxProduct, ISampleBoxProductDBRepository>, ISampleBoxProductGetByIdCommand
    {

        public SampleBoxProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxProductGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SampleBoxProductGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SampleBoxProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductAmmount = getByIdResult.Bag.ProductAmount,
                        SampleBoxId = getByIdResult.Bag.SampleBoxId,
                        RelatedProductId = getByIdResult.Bag.ProductId,
                    };
                }
            }

            return result;
        }
    }
}
