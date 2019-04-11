using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using DomainModel.Company.Customer;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

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
