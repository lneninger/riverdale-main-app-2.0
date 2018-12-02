using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand
{
    public class CustomerFreightoutDeleteCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutDeleteCommand
    {
        public CustomerFreightoutDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerFreightoutDeleteCommandOutputDTO Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
