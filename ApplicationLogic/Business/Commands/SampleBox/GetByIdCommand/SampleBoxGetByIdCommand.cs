using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand
{
    public class SampleBoxGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBox, ISampleBoxDBRepository>, ISampleBoxGetByIdCommand
    {

        public SampleBoxGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SampleBoxGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SampleBoxGetByIdCommandOutputDTO
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
