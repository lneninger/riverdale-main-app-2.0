using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand
{
    public class CustomerFreightoutGetAllCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutGetAllCommand
    {
        public CustomerFreightoutGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<CustomerFreightoutGetAllCommandOutputDTO>> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
