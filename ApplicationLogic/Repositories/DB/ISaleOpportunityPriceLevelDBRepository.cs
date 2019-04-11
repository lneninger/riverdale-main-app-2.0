using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityTargetPriceDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityTargetPrice>> GetAll();

        OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPricePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice> GetById(int id, bool forceRefresh = false);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice> GetByIdWithProducts(int id);

        OperationResponse Insert(SaleOpportunityTargetPrice entity);

        OperationResponse Delete(SaleOpportunityTargetPrice entity);

        OperationResponse LogicalDelete(SaleOpportunityTargetPrice entity);

    }
}
