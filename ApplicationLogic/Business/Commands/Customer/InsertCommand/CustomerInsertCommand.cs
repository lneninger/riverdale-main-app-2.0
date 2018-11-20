using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.InsertCommand.Models;

namespace FocusServices.Business.Commands.Customer.InsertCommand
{
    public class CustomerInsertCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerInsertCommand
    {
        public CustomerInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerInsertCommandOutputDTO Execute(CustomerInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
