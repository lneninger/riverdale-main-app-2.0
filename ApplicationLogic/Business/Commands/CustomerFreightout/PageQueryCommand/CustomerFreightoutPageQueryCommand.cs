using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand
{
    public class CustomerFreightoutPageQueryCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutPageQueryCommand
    {
        public CustomerFreightoutPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public PageResult<CustomerFreightoutPageQueryCommandOutputDTO> Execute(PageQuery<CustomerFreightoutPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
