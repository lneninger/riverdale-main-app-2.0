using System;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand
{
    public class CustomerFreightoutGetByIdCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutGetByIdCommand
    {

        public CustomerFreightoutGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerFreightoutGetByIdCommandOutputDTO Execute(int id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
