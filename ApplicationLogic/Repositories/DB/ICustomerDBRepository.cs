using DomainModel;
using FocusServices.Business.Commands.Customer.DeleteCommand.Models;
using FocusServices.Business.Commands.Customer.GetAllCommand.Models;
using FocusServices.Business.Commands.Customer.GetByIdCommand.Models;
using FocusServices.Business.Commands.Customer.InsertCommand.Models;
using FocusServices.Business.Commands.Customer.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Repositories.DB
{
    public interface ICustomerDBRepository: IDBRepository<Customer>
    {
        IEnumerable<CustomerGetAllCommandOutputDTO> GetAll();
        CustomerGetByIdCommandOutputDTO GetById(int id);
        CustomerInsertCommandOutputDTO Insert(CustomerInsertCommandInputDTO input);
        CustomerUpdateCommandOutputDTO Update(CustomerUpdateCommandInputDTO input);
        CustomerDeleteCommandOutputDTO Delete(int id);
    }
}
