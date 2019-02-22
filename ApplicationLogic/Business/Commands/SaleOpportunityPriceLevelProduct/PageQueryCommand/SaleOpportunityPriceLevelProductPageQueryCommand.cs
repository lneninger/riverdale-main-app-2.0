using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand
{
    public class SaleOpportunityPriceLevelProductPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevelProduct, ISaleOpportunityPriceLevelProductDBRepository>, ISaleOpportunityPriceLevelProductPageQueryCommand
    {
        public SaleOpportunityPriceLevelProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>> Execute(PageQuery<SaleOpportunityPriceLevelProductPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
