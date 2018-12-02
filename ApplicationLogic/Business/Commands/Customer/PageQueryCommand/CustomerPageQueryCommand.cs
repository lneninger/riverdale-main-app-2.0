using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Business.Commands.Customer.PageQueryCommand
{
    public class CustomerPageQueryCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerPageQueryCommand
    {
        public CustomerPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public PageResult<CustomerPageQueryCommandOutputDTO> Execute(PageQuery<CustomerPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
