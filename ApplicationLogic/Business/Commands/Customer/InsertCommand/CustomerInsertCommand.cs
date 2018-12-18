using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand
{
    public class CustomerInsertCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerInsertCommand
    {
        public CustomerInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerInsertCommandOutputDTO> Execute(CustomerInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
