using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand
{
    public class SaleOpportunityPriceLevelProductGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevelProduct, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductGetByIdCommand
    {

        public SaleOpportunityPriceLevelProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductAmmount = getByIdResult.Bag.ProductAmount,
                        SaleOpportunityPriceLevelId = getByIdResult.Bag.SaleOpportunityPriceLevelId,
                        RelatedProductId = getByIdResult.Bag.ProductId,
                    };
                }
            }

            return result;
        }
    }
}
