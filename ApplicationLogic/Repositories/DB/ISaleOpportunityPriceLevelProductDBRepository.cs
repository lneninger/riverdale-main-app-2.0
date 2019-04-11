using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityTargetPriceProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityTargetPriceProduct>> GetAll();

        OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO> input);

        OperationResponse<SaleOpportunityTargetPriceProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SaleOpportunityTargetPriceProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SaleOpportunityTargetPriceProduct entity);

        OperationResponse Delete(SaleOpportunityTargetPriceProduct entity);

        OperationResponse LogicalDelete(SaleOpportunityTargetPriceProduct entity);

        void Detach(int id);

    }
}
