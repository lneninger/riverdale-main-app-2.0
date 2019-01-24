using DomainModel.Company.Grower;
using ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Grower.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Grower.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;

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
