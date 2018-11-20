using System;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.GetByIdCommand.Models;

namespace FocusServices.Business.Commands.Customer.GetByIdCommand
{
    public class CustomerGetByIdCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerGetByIdCommand
    {
        public CustomerGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerGetByIdCommandOutputDTO Execute(int id)
        {
            return this.Repository.GetById(id);
        }
    }
}
