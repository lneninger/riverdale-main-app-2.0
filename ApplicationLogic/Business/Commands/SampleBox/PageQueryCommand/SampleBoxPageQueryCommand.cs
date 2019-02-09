using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand
{
    public class SampleBoxPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBox, ISampleBoxDBRepository>, ISampleBoxPageQueryCommand
    {
        public SampleBoxPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>> Execute(PageQuery<SampleBoxPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
