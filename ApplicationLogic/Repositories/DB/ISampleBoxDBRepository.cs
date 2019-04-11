using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISampleBoxDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SampleBox>> GetAll();

        OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxPageQueryCommandInputDTO> input);

        OperationResponse<SampleBox> GetById(int id, bool forceRefresh = false);

        OperationResponse<SampleBox> GetByIdWithMedias(int id);

        OperationResponse Insert(SampleBox entity);

        OperationResponse Delete(SampleBox entity);

        OperationResponse LogicalDelete(SampleBox entity);

        void Detach(int id);

    }
}
