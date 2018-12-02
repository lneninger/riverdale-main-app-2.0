using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand
{
    public class CustomerFreightoutInsertCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutInsertCommand
    {
        public CustomerFreightoutInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerFreightoutInsertCommandOutputDTO Execute(CustomerFreightoutInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
