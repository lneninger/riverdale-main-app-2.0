using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using DomainModel.Company.Customer;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

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
