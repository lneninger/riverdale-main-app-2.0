using ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using DomainModel.Company.Grower;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IGrowerDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<Grower>> GetAll();

        OperationResponse<PageResult<GrowerPageQueryCommandOutputDTO>> PageQuery(PageQuery<GrowerPageQueryCommandInputDTO> input);

        OperationResponse<Grower> GetById(int id);

        OperationResponse Insert(Grower entity);

        //OperationResponse<GrowerUpdateCommandOutputDTO> Update(GrowerUpdateCommandInputDTO input);

        OperationResponse<GrowerDeleteCommandOutputDTO> LogicalDelete(Grower entity);

        OperationResponse<GrowerDeleteCommandOutputDTO> Delete(Grower entity);
    }
}
