using ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunity>> GetAll();

        OperationResponse<PageResult<SaleOpportunityPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetById(int id);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetByIdWithProducts(int id);

        OperationResponse Insert(SaleOpportunity entity);

        OperationResponse Delete(SaleOpportunity entity);

        OperationResponse LogicalDelete(SaleOpportunity entity);

    }
}
