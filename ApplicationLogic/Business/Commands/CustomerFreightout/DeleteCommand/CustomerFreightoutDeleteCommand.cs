using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand
{
    public class CustomerFreightoutDeleteCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutDeleteCommand
    {
        public CustomerFreightoutDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerFreightoutDeleteCommandOutputDTO> Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
