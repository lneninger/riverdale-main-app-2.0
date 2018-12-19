using DomainModel;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface ICustomerFreightoutDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<CustomerFreightout>> GetAll();
        OperationResponse<PageResult<CustomerFreightoutPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerFreightoutPageQueryCommandInputDTO> input);
        OperationResponse<CustomerFreightout> GetById(int id);
        OperationResponse Insert(CustomerFreightout input);
        //OperationResponse<CustomerFreightoutUpdateCommandOutputDTO> Update(CustomerFreightoutUpdateCommandInputDTO input);
        OperationResponse<CustomerFreightoutDeleteCommandOutputDTO> Delete(int id);
    }
}
