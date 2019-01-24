using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Grower.PageQueryCommand
{
    public class GrowerPageQueryCommand : AbstractDBCommand<DomainModel.Company.Grower.Grower, IGrowerDBRepository>, IGrowerPageQueryCommand
    {
        public GrowerPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IGrowerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<GrowerPageQueryCommandOutputDTO>> Execute(PageQuery<GrowerPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
