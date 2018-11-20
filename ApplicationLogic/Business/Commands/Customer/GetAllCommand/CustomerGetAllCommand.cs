using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.GetAllCommand.Models;

namespace FocusServices.Business.Commands.Customer.GetAllCommand
{
    public class CustomerGetAllCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerGetAllCommand
    {
        public CustomerGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public IEnumerable<CustomerGetAllCommandOutputDTO> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
