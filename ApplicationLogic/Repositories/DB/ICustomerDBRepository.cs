using DomainModel.Company.Customer;
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
using Framework.Core.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface ICustomerDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<Customer>> GetAll();

        OperationResponse<PageResult<CustomerPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerPageQueryCommandInputDTO> input);

        OperationResponse<Customer> GetById(int id);

        OperationResponse Insert(Customer entity);

        //OperationResponse<CustomerUpdateCommandOutputDTO> Update(CustomerUpdateCommandInputDTO input);

        OperationResponse<CustomerDeleteCommandOutputDTO> LogicalDelete(Customer entity);

        OperationResponse<CustomerDeleteCommandOutputDTO> Delete(Customer entity);
    }
}
