using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand
{
    public class CustomerDeleteCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerDeleteCommand
    {
        public CustomerDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerDeleteCommandOutputDTO> Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
