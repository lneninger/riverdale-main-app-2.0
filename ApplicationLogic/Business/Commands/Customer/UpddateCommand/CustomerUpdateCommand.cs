using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.UpdateCommand.Models;

namespace FocusServices.Business.Commands.Customer.UpdateCommand
{
    public class CustomerUpdateCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerUpdateCommand
    {
        public CustomerUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerUpdateCommandOutputDTO Execute(CustomerUpdateCommandInputDTO input)
        {
            return this.Repository.Update(input);
        }
    }
}
