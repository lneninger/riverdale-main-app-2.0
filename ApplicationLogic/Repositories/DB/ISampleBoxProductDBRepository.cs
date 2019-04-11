using ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISampleBoxProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SampleBoxProduct>> GetAll();

        OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxProductPageQueryCommandInputDTO> input);

        OperationResponse<SampleBoxProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SampleBoxProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SampleBoxProduct entity);

        OperationResponse Delete(SampleBoxProduct entity);

        OperationResponse LogicalDelete(SampleBoxProduct entity);

        void Detach(int id);

    }
}
