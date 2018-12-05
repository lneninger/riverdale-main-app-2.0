using DomainModel;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface ICustomerDBRepository: IDBRepository
    {
        IEnumerable<CustomerGetAllCommandOutputDTO> GetAll();

        PageResult<CustomerPageQueryCommandOutputDTO> PageQuery(PageQuery<CustomerPageQueryCommandInputDTO> input);

        CustomerGetByIdCommandOutputDTO GetById(int id);

        OperationResponse<CustomerInsertCommandOutputDTO> Insert(CustomerInsertCommandInputDTO input);

        OperationResponse<CustomerUpdateCommandOutputDTO> Update(CustomerUpdateCommandInputDTO input);

        OperationResponse<CustomerDeleteCommandOutputDTO> Delete(int id);
    }
}
