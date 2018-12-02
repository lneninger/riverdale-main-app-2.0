using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand
{
    public class CustomerUpdateCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerUpdateCommand
    {
        public CustomerUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerUpdateCommandOutputDTO Execute(CustomerUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
